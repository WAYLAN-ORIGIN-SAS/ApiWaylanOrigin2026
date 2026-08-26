namespace API_Waylan_Origin.DTOs.CitaSemanal
{
    public class CitaSemanalGetDto
    {
       

        // HERO
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string HeroImageUrl { get; set; } = string.Empty;

        // HISTORIA
        public string HistoriaTitulo { get; set; } = string.Empty;
        public string HistoriaParrafo1 { get; set; } = string.Empty;
        public string HistoriaParrafo2 { get; set; } = string.Empty;
        public string Testimonio { get; set; } = string.Empty;

        // RAZONES
        public string RazonesTitulo { get; set; } = string.Empty;
        public string Razon1Titulo { get; set; } = string.Empty;
        public string Razon1Texto { get; set; } = string.Empty;
        public string Razon2Titulo { get; set; } = string.Empty;
        public string Razon2Texto { get; set; } = string.Empty;
        public string Razon3Titulo { get; set; } = string.Empty;
        public string Razon3Texto { get; set; } = string.Empty;

        // OPTIMIZACIÓN
        public string OptCard1ImageUrl { get; set; } = string.Empty;
        public string OptCard1Titulo { get; set; } = string.Empty;
        public string OptCard1Texto { get; set; } = string.Empty;

        public string OptCard2ImageUrl { get; set; } = string.Empty;
        public string OptCard2Titulo { get; set; } = string.Empty;
        public string OptCard2Texto { get; set; } = string.Empty;

        // PROCESO
        public string ProcesoEtapa1Titulo { get; set; } = string.Empty;
        public string ProcesoEtapa1Texto { get; set; } = string.Empty;
        public string ProcesoEtapa2Titulo { get; set; } = string.Empty;
        public string ProcesoEtapa2Texto { get; set; } = string.Empty;
        public string ProcesoEtapa3Titulo { get; set; } = string.Empty;
        public string ProcesoEtapa3Texto { get; set; } = string.Empty;
        public string ProcesoEtapa4Titulo { get; set; } = string.Empty;
        public string ProcesoEtapa4Texto { get; set; } = string.Empty;
        public string ProcesoEtapa5Titulo { get; set; } = string.Empty;
        public string ProcesoEtapa5Texto { get; set; } = string.Empty;

        // CALLOUT
        public string CalloutTitulo { get; set; } = string.Empty;
        public string CalloutTexto { get; set; } = string.Empty;
    }
}
