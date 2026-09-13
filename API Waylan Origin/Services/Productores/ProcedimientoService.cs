using API_Waylan_Origin.Data;
using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Interfaces.Productores;
using API_Waylan_Origin.Models;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;

namespace API_Waylan_Origin.Services.Productores
{
    public class ProcedimientoService : IProcedimientoService
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<ProcedimientoService> _logger;

        public ProcedimientoService(AppDbContext appDbContext, IMapper mapper, IConfiguration config, ILogger<ProcedimientoService> logger)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _config = config;
            _logger = logger;
        }

        public async Task<ProcedimientoReadDto> CrearProcedimiento(ProcedimientoCreateDto procedimientoCreateDto)
        {
            await validarProductor(procedimientoCreateDto.IdProductor);

            var NuevoProcedimiento = _mapper.Map<Procedimiento>(procedimientoCreateDto);

            // 2. Inicializar cliente de Azure Blob Storage
            string connectionString = _config.GetConnectionString("AzureBlobStorage");
            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("imagenes");
            string urlFotoDefecto = "https://storagewaylan.blob.core.windows.net/imagenes/ImagenDefecto.png";

            // 3. Procesar ImagenPrincipal (IFormFile)
            if (procedimientoCreateDto.Imagen != null && procedimientoCreateDto.Imagen.Length > 0)
            {
                string nombreUnico = Guid.NewGuid().ToString() + Path.GetExtension(procedimientoCreateDto.Imagen.FileName);
                var blobClient = blobContainerClient.GetBlobClient(nombreUnico);

                using (var stream = procedimientoCreateDto.Imagen.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                NuevoProcedimiento.Imagen = blobClient.Uri.ToString();
            }
            else
            {
                NuevoProcedimiento.Imagen = urlFotoDefecto;
            }

            _appDbContext.Procedimientos.Add(NuevoProcedimiento);
            await _appDbContext.SaveChangesAsync();

            await _appDbContext.Entry(NuevoProcedimiento).Reference(p => p.Productor).LoadAsync();

            return _mapper.Map<ProcedimientoReadDto>(NuevoProcedimiento);
        }

        public async Task<IEnumerable<ProcedimientoReadDto>> ListarProcedimientos()
        {
            var procedimientos = await _appDbContext.Procedimientos
                .Include(pr => pr.Productor)
                .ToListAsync();

            if(procedimientos == null) 
                return new List<ProcedimientoReadDto>();

            return _mapper.Map<IEnumerable<ProcedimientoReadDto>>(procedimientos);


        }
        public async Task<ProcedimientoReadDto> ActualizarProcedimiento(int id, ProcedimientoUpdateDto procedimientoUpdateDto)
        {
            // 1. Obtener el procedimiento existente con sus relaciones
            var procedimientoExistente = await _appDbContext.Procedimientos
                .Include(p => p.Productor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (procedimientoExistente == null)
                throw new KeyNotFoundException($"El procedimiento con ID {id} no existe.");

            // 2. Validar que el productor asignado exista
            await validarProductor(procedimientoUpdateDto.IdProductor);

            // 3. Guardar la URL actual de la imagen antes del mapeo
            string? rutaFotoVieja = procedimientoExistente.Imagen;

            // 4. Mapear las propiedades de texto enviadas en el DTO
            _mapper.Map(procedimientoUpdateDto, procedimientoExistente);

            // 5. Inicializar cliente de Azure Blob Storage
            string connectionString = _config.GetConnectionString("AzureBlobStorage");
            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("imagenes");
            string urlFotoDefecto = "https://storagewaylan.blob.core.windows.net/imagenes/ImagenDefecto.png";

            // 6. Procesar cambio de imagen (si se adjuntó un nuevo archivo)
            if (procedimientoUpdateDto.Imagen != null && procedimientoUpdateDto.Imagen.Length > 0)
            {
                string nombreUnico = Guid.NewGuid().ToString() + Path.GetExtension(procedimientoUpdateDto.Imagen.FileName);
                var blobNuevoClient = blobContainerClient.GetBlobClient(nombreUnico);

                using (var stream = procedimientoUpdateDto.Imagen.OpenReadStream())
                {
                    await blobNuevoClient.UploadAsync(stream, true);
                }

                procedimientoExistente.Imagen = blobNuevoClient.Uri.ToString();

                // Borrar la imagen anterior en Azure Blob Storage (siempre que no sea la imagen por defecto)
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
                // Si no se envió archivo nuevo, mantenemos la imagen existente
                procedimientoExistente.Imagen = rutaFotoVieja;
            }

            // 7. Persistir cambios en la base de datos
            await _appDbContext.SaveChangesAsync();

            // 8. Recargar la entidad del productor para asegurar datos completos en el DTO
            await _appDbContext.Entry(procedimientoExistente).Reference(p => p.Productor).LoadAsync();

            return _mapper.Map<ProcedimientoReadDto>(procedimientoExistente);
        }


        private async Task validarProductor(int id)
        {
            var productor = await _appDbContext.Productores
                .AnyAsync(p  => p.Id == id);

            if (!productor)
                throw new KeyNotFoundException($"El productor con el ID {id} No Existe");
        }

    }
}