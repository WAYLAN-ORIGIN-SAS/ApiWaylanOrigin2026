using API_Waylan_Origin.Models;
using API_Waylan_Origin.DTOs.CitaSemanal;

namespace API_Waylan_Origin.Interfaces.CitasSemanales
{
    public interface ICitasService
    {
        Task<CitaSemanalGetDto> GetCita();

        Task<bool> UpdateCita(CitaSemanalUpdateDto citaSemanalUpdateDto);
    }
}
