namespace API_Waylan_Origin.Models
{
    public class CitaSemanal
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string HistoriaParrafo1 { get; set; } = string.Empty;
        public string HistoriaParrafo2 { get; set; } = string.Empty;
        
    }
}
