using API_Waylan_Origin.Data;
using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Interfaces.Productores;
using API_Waylan_Origin.Models;
using API_Waylan_Origin.Services.Productos;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace API_Waylan_Origin.Services.Productores
{
    public class OrganizacionesService : IOrganizacionesService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<OrganizacionesService> _logger;

        public OrganizacionesService(AppDbContext appDbContext, IMapper mapper, IConfiguration configuration, ILogger<OrganizacionesService> logger)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _config = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<OrganizacionReadDto>> ListrarOrganizaciones()
        {
            var organizaciones = await _appDbContext.Organizaciones
                .Include(o => o.productores)
                .ToListAsync();

            if(organizaciones == null)
                return new List<OrganizacionReadDto>();

            return _mapper.Map<IEnumerable<OrganizacionReadDto>>(organizaciones);
        }
      
        public async Task<OrganizacionReadDto> ActualizarOrganizacion(int IdOrganizacion, OrganizacionUpdateDto organizacionDto)
        {
            var organizacionUpdate = await _appDbContext.Organizaciones
                .Include(o => o.productores)
                .FirstOrDefaultAsync(o => o.Id == IdOrganizacion);

            if(organizacionUpdate == null)
                throw new KeyNotFoundException($"La organizacion No Existe");

            // 1. Guardamos las URLs viejas antes de que AutoMapper o el proceso las sobrescriba
            string? rutaLogoVieja = organizacionUpdate.ImagenLogo;
            string? rutaHeroVieja = organizacionUpdate.ImagenHero;

            // 2. Mapeamos las propiedades de texto
            _mapper.Map(organizacionDto, organizacionUpdate);

            // 3. Inicializamos la conexión a Azure Blob Storage
            string connectionString = _config.GetConnectionString("AzureBlobStorage");
            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("imagenes");
            string urlFotoDefecto = "https://storagewaylan.blob.core.windows.net/imagenes/ImagenDefecto.png";

            // 4. PROCESAR IMAGEN LOGO
            if (organizacionDto.Logo != null && organizacionDto.Logo.Length > 0)
            {
                string nombreUnicoLogo = Guid.NewGuid().ToString() + Path.GetExtension(organizacionDto.Logo.FileName);
                var blobNuevoLogo = blobContainerClient.GetBlobClient(nombreUnicoLogo);

                using (var stream = organizacionDto.Logo.OpenReadStream())
                {
                    await blobNuevoLogo.UploadAsync(stream, true);
                }

                organizacionUpdate.ImagenLogo = blobNuevoLogo.Uri.ToString();

                // Eliminar Logo anterior de Azure
                if (!string.IsNullOrEmpty(rutaLogoVieja) && rutaLogoVieja != urlFotoDefecto)
                {
                    try
                    {
                        var uri = new Uri(rutaLogoVieja);
                        string nombreBlobViejo = Path.GetFileName(uri.LocalPath);
                        var blobViejoClient = blobContainerClient.GetBlobClient(nombreBlobViejo);
                        await blobViejoClient.DeleteIfExistsAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "No se pudo eliminar el Logo viejo {Ruta} de Azure Blob Storage.", rutaLogoVieja);
                    }
                }
            }
            else
            {
                organizacionUpdate.ImagenLogo = rutaLogoVieja;
            }

            // 5. PROCESAR IMAGEN HERO
            if (organizacionDto.HeroImagen != null && organizacionDto.HeroImagen.Length > 0)
            {
                string nombreUnicoHero = Guid.NewGuid().ToString() + Path.GetExtension(organizacionDto.HeroImagen.FileName);
                var blobNuevoHero = blobContainerClient.GetBlobClient(nombreUnicoHero);

                using (var stream = organizacionDto.HeroImagen.OpenReadStream())
                {
                    await blobNuevoHero.UploadAsync(stream, true);
                }

                organizacionUpdate.ImagenHero = blobNuevoHero.Uri.ToString();

                // Eliminar Hero anterior de Azure
                if (!string.IsNullOrEmpty(rutaHeroVieja) && rutaHeroVieja != urlFotoDefecto)
                {
                    try
                    {
                        var uri = new Uri(rutaHeroVieja);
                        string nombreBlobViejo = Path.GetFileName(uri.LocalPath);
                        var blobViejoClient = blobContainerClient.GetBlobClient(nombreBlobViejo);
                        await blobViejoClient.DeleteIfExistsAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "No se pudo eliminar la imagen Hero vieja {Ruta} de Azure Blob Storage.", rutaHeroVieja);
                    }
                }
            }
            else
            {
                organizacionUpdate.ImagenHero = rutaHeroVieja;
            }

            // 6. Guardar cambios y retornar DTO
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<OrganizacionReadDto>(organizacionUpdate);


        }
    }
}
