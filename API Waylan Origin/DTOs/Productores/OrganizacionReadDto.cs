using API_Waylan_Origin.Models;

namespace API_Waylan_Origin.DTOs.Productores
{
    public class OrganizacionReadDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string HeroImagen { get; set; } = string.Empty;
        public string Descripcion1 { get; set; } = string.Empty;
        public string Descripcion2 { get; set; } = string.Empty;
        public string Enfoque { get; set; } = string.Empty;

        public List<ProductorReadDto> productoresDestacados { get; set; } = new();
    }
}
