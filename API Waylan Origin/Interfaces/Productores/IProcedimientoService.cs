using API_Waylan_Origin.DTOs.Productores;

namespace API_Waylan_Origin.Interfaces.Productores
{
    public interface IProcedimientoService
    {
        Task<ProcedimientoReadDto> CrearProcedimiento(ProcedimientoCreateDto procedimientoCreateDto);
        Task<IEnumerable<ProcedimientoReadDto>> ListarProcedimientos();
        Task<ProcedimientoReadDto> ActualizarProcedimiento(int id, ProcedimientoUpdateDto procedimientoUpdateDto);

    }
}
