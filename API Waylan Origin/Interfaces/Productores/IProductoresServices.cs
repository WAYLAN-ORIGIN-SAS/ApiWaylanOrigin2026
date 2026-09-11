using API_Waylan_Origin.DTOs.Productores;
using API_Waylan_Origin.Services.Productores;

namespace API_Waylan_Origin.Interfaces.Productores
{
    public interface IProductoresServices
    {
        Task<ProductorReadDto> CrearProductor(ProductorCreateDto productorDto);
        Task<IEnumerable<ProductorReadDto>> ListarProductores();
        Task<IEnumerable<ProductorReadDto>> ListarProductoresDestacados();
        Task<ProductorReadDto> ActualizarProductor(int id, ProductorUpdateDto productorUpdateDto);
    }
}
