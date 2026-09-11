using API_Waylan_Origin.Enums;

namespace API_Waylan_Origin.Models
{
    public class Productor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdOrganizacion { get; set; }
        public bool Destacado { get; set; }
        public string ImagenPrincipal { get; set; } = string.Empty;
        public string Frase { get; set; } = string.Empty;
        public string HistoriaTitulo { get; set; } = string.Empty;
        public string HistoriaTexto { get; set; } = string.Empty;
        public string SostenibilidadDescripcion { get; set; } = string.Empty;

        public Organizacion Organizacion { get; set; } = null!;
        public ICollection<Procedimiento> Procedimientos { get; set; } = new HashSet<Procedimiento>();
    }
}
