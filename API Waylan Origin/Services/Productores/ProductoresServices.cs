using API_Waylan_Origin.Data;
using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Interfaces.Productores;
using API_Waylan_Origin.Models;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;

namespace API_Waylan_Origin.Services.Productores
{
    public class ProductoresServices : IProductoresServices
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<ProductoresServices> _logger;

        public ProductoresServices(AppDbContext appDbContext, IMapper mapper, IConfiguration config, ILogger<ProductoresServices> logger)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _config = config;
            _logger = logger;
        }

        public async Task<ProductorReadDto> CrearProductor(ProductorCreateDto productorDto)
        {
            
            
            await validarOrganizacion(productorDto.IdOrganizacion);

            // 1. Mapear DTO a la Entidad Productor
            var nuevoProductor = _mapper.Map<Productor>(productorDto);

            // 2. Inicializar cliente de Azure Blob Storage
            string connectionString = _config.GetConnectionString("AzureBlobStorage");
            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("imagenes");
            string urlFotoDefecto = "https://storagewaylan.blob.core.windows.net/imagenes/ImagenDefecto.png";

            // 3. Procesar ImagenPrincipal (IFormFile)
            if (productorDto.ImagenPrincipal != null && productorDto.ImagenPrincipal.Length > 0)
            {
                string nombreUnico = Guid.NewGuid().ToString() + Path.GetExtension(productorDto.ImagenPrincipal.FileName);
                var blobClient = blobContainerClient.GetBlobClient(nombreUnico);

                using (var stream = productorDto.ImagenPrincipal.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                nuevoProductor.ImagenPrincipal = blobClient.Uri.ToString();
            }
            else
            {
                nuevoProductor.ImagenPrincipal = urlFotoDefecto;
            }

            // 4. Persistir en la base de datos
            _appDbContext.Productores.Add(nuevoProductor);
            await _appDbContext.SaveChangesAsync();

            // 5. Cargar relaciones para retornarlas correctamente en el DTO de lectura
            await _appDbContext.Entry(nuevoProductor).Reference(p => p.Organizacion).LoadAsync();
            await _appDbContext.Entry(nuevoProductor).Collection(p => p.Procedimientos).LoadAsync();

            return _mapper.Map<ProductorReadDto>(nuevoProductor);
        }
        
        public async Task<IEnumerable<ProductorReadDto>> ListarProductores()
        {
            var productores = await _appDbContext.Productores
                .Include(p => p.Organizacion)
                .Include(p => p.Procedimientos)
                .ToListAsync();

            if(productores == null)
                return new List<ProductorReadDto>();

            return _mapper.Map<IEnumerable<ProductorReadDto>>(productores);
        }
        public async Task<IEnumerable<ProductorReadDto>> ListarProductoresDestacados()
        {
            var productores = await _appDbContext.Productores
               .Include(p => p.Organizacion)
               .Include(p => p.Procedimientos)
               .Where(p => p.Destacado == true)
               .ToListAsync();

            if (productores == null)
                return new List<ProductorReadDto>();

            return _mapper.Map<IEnumerable<ProductorReadDto>>(productores);
        }
        public async Task<ProductorReadDto> ActualizarProductor(int id, ProductorUpdateDto productorUpdateDto)
        {
            // 1. Obtener el productor existente junto con sus relaciones
            var productorExistente = await _appDbContext.Productores
                .Include(p => p.Organizacion)
                .Include(p => p.Procedimientos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (productorExistente == null)
                throw new KeyNotFoundException($"El productor con ID {id} no existe.");

            await validarOrganizacion(productorUpdateDto.IdOrganizacion);

            // 2. Guardar la URL actual de la imagen antes del mapeo
            string? rutaFotoVieja = productorExistente.ImagenPrincipal;

            // 3. Mapear las propiedades de texto enviadas en el DTO
            _mapper.Map(productorUpdateDto, productorExistente);

            // 4. Inicializar clientes de Azure Blob Storage
            string connectionString = _config.GetConnectionString("AzureBlobStorage");
            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("imagenes");
            string urlFotoDefecto = "https://storagewaylan.blob.core.windows.net/imagenes/ImagenDefecto.png";

            // 5. Procesar cambio de ImagenPrincipal (si se subió un nuevo archivo)
            if (productorUpdateDto.ImagenPrincipal != null && productorUpdateDto.ImagenPrincipal.Length > 0)
            {
                string nombreUnico = Guid.NewGuid().ToString() + Path.GetExtension(productorUpdateDto.ImagenPrincipal.FileName);
                var blobNuevoClient = blobContainerClient.GetBlobClient(nombreUnico);

                using (var stream = productorUpdateDto.ImagenPrincipal.OpenReadStream())
                {
                    await blobNuevoClient.UploadAsync(stream, true);
                }

                productorExistente.ImagenPrincipal = blobNuevoClient.Uri.ToString();

                // Borrar la imagen anterior en Azure Blob Storage (siempre que no sea la por defecto)
                if (!string.IsNullOrEmpty(rutaFotoVieja) && rutaFotoVieja != urlFotoDefecto)
                {
                    try
                    {
                        var uri = new Uri(rutaFotoVieja);
                        string nombreBlobViejo = Path.GetFileName(uri.LocalPath);
                        var blobViejoClient = blobContainerClient.GetBlobClient(nombreBlobViejo);
                        await blobViejoClient.DeleteIfExistsAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "No se pudo eliminar la imagen vieja {Ruta} de Azure Blob Storage.", rutaFotoVieja);
                    }
                }
            }
            else
            {
                // Si no se adjuntó nuevo archivo, mantener la imagen que tenía previamente
                productorExistente.ImagenPrincipal = rutaFotoVieja;
            }

            // 6. Persistir cambios en la base de datos
            await _appDbContext.SaveChangesAsync();

            // 7. Recargar relaciones para asegurar que el DTO devuelva datos actualizados (ej: nueva organización)
            await _appDbContext.Entry(productorExistente).Reference(p => p.Organizacion).LoadAsync();
            await _appDbContext.Entry(productorExistente).Collection(p => p.Procedimientos).LoadAsync();

            return _mapper.Map<ProductorReadDto>(productorExistente);
        }

        //METODOS SECUNDARIOS
        private async Task validarOrganizacion(int id)
        {
            var org = await _appDbContext.Organizaciones
                .AnyAsync(o => o.Id == id);

            if(!org)
                throw new KeyNotFoundException($"La organizacion con el ID {id} No Existe");
        }
    }
}
