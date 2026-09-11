using System.ComponentModel.DataAnnotations;

namespace API_Waylan_Origin.DTOs.Productores
{
    public class ProcedimientoUpdateDto
    {
        [Required(ErrorMessage = "El Id del productor es obligatorio.")]
        public int IdProductor { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El titulo es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Descripcion es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Imagen es obligatoria.")]
        public IFormFile? Imagen { get; set; }
    }
}
