using API_Waylan_Origin.DTOs.Productores;

namespace API_Waylan_Origin.Interfaces.Productores
{
    public interface IOrganizacionesService
    {
       
        Task<IEnumerable<OrganizacionReadDto>> ListrarOrganizaciones();
        Task<OrganizacionReadDto> ActualizarOrganizacion(int IdOrganizacion, OrganizacionUpdateDto organizacionDto);
    }
}
