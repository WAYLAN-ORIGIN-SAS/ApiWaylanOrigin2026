using System.ComponentModel.DataAnnotations;

namespace API_Waylan_Origin.DTOs.CitaSemanal
{
    public class CitaSemanalUpdateDto
    {
        // HERO
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public string Fecha { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        public string Ubicacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La imagen principal (Hero) es obligatoria.")]
        public string HeroImageUrl { get; set; } = string.Empty;

        // HISTORIA
        [Required(ErrorMessage = "El título de la historia es obligatorio.")]
        public string HistoriaTitulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer párrafo de la historia es obligatorio.")]
        public string HistoriaParrafo1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo párrafo de la historia es obligatorio.")]
        public string HistoriaParrafo2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "El testimonio es obligatorio.")]
        public string Testimonio { get; set; } = string.Empty;

        // RAZONES
        [Required(ErrorMessage = "El título de la sección de razones es obligatorio.")]
        public string RazonesTitulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la razón 1 es obligatorio.")]
        public string Razon1Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la razón 1 es obligatorio.")]
        public string Razon1Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la razón 2 es obligatorio.")]
        public string Razon2Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la razón 2 es obligatorio.")]
        public string Razon2Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la razón 3 es obligatorio.")]
        public string Razon3Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la razón 3 es obligatorio.")]
        public string Razon3Texto { get; set; } = string.Empty;

        // OPTIMIZACIÓN
        [Required(ErrorMessage = "La imagen de la tarjeta de optimización 1 es obligatoria.")]
        public string OptCard1ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la tarjeta de optimización 1 es obligatorio.")]
        public string OptCard1Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la tarjeta de optimización 1 es obligatorio.")]
        public string OptCard1Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La imagen de la tarjeta de optimización 2 es obligatoria.")]
        public string OptCard2ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la tarjeta de optimización 2 es obligatorio.")]
        public string OptCard2Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la tarjeta de optimización 2 es obligatorio.")]
        public string OptCard2Texto { get; set; } = string.Empty;

        // PROCESO
        [Required(ErrorMessage = "El título de la etapa 1 del proceso es obligatorio.")]
        public string ProcesoEtapa1Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la etapa 1 del proceso es obligatorio.")]
        public string ProcesoEtapa1Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la etapa 2 del proceso es obligatorio.")]
        public string ProcesoEtapa2Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la etapa 2 del proceso es obligatorio.")]
        public string ProcesoEtapa2Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la etapa 3 del proceso es obligatorio.")]
        public string ProcesoEtapa3Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la etapa 3 del proceso es obligatorio.")]
        public string ProcesoEtapa3Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la etapa 4 del proceso es obligatorio.")]
        public string ProcesoEtapa4Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la etapa 4 del proceso es obligatorio.")]
        public string ProcesoEtapa4Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la etapa 5 del proceso es obligatorio.")]
        public string ProcesoEtapa5Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto de la etapa 5 del proceso es obligatorio.")]
        public string ProcesoEtapa5Texto { get; set; } = string.Empty;

        // CALLOUT
        [Required(ErrorMessage = "El título del Callout es obligatorio.")]
        public string CalloutTitulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El texto del Callout es obligatorio.")]
        public string CalloutTexto { get; set; } = string.Empty;
    }
}
