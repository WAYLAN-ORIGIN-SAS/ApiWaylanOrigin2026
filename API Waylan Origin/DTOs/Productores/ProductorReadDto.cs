using API_Waylan_Origin.Models;

namespace API_Waylan_Origin.DTOs.Productores
{
    public class ProductorReadDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string OrganizacionNombre { get; set; } = string.Empty;
        public bool Destacado { get; set; }
        public string ImagenPrincipal { get; set; } = string.Empty;
        public string Frase { get; set; } = string.Empty;
        public string HistoriaTitulo { get; set; } = string.Empty;
        public string HistoriaTexto { get; set; } = string.Empty;
        public string SostenibilidadDescripcion { get; set; } = string.Empty;

        public ICollection<ProcedimientoReadDto> Procedimientos { get; set; } = new List<ProcedimientoReadDto>();
    }
}
