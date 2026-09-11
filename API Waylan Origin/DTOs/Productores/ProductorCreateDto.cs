using API_Waylan_Origin.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Waylan_Origin.DTOs.Productores
{
    public class ProductorCreateDto
    {
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Id de la organizacion es obligatorio.")]
        public int IdOrganizacion { get; set; }

        [Required(ErrorMessage = "El destacado es obligatorio.")]
        public bool Destacado { get; set; }

        [Required(ErrorMessage = "La imagen es obligatorio.")]
        public IFormFile? ImagenPrincipal { get; set; } 

        [Required(ErrorMessage = "La frase es obligatoria.")]
        public string Frase { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Historia de titulo es obligatorio.")]
        public string HistoriaTitulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Historia del texto es obligatorio.")]
        public string HistoriaTexto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion de sostenibilidad es obligatorio.")]
        public string SostenibilidadDescripcion { get; set; } = string.Empty;

        public ICollection<Procedimiento> Procedimientos { get; set; } = new List<Procedimiento>();
    }
}
