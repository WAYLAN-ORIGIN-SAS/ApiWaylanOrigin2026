using API_Waylan_Origin.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Waylan_Origin.DTOs.Productores
{
    public class OrganizacionUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la organización es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
        public IFormFile? Logo { get; set; }
        [Required(ErrorMessage = "La HeroImagen es obligatoria.")]
        public IFormFile? HeroImagen { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatoria.")]
        public string Descripcion1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "El enfoque es obligatoria.")]
        public string Enfoque { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los productores son obligatorios")]
        public ICollection<Productor> productores { get; set; } = new List<Productor>();
    }
}
