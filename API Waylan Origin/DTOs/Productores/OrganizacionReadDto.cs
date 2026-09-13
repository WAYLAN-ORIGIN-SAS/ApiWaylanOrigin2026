using API_Waylan_Origin.Models;

namespace API_Waylan_Origin.DTOs.Productores
{
    public class OrganizacionReadDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string ImagenLogo { get; set; } = string.Empty;
        public string ImagenHero { get; set; } = string.Empty;
        public string Descripcion1 { get; set; } = string.Empty;
        public string Descripcion2 { get; set; } = string.Empty;
        public string Enfoque { get; set; } = string.Empty;

        public ICollection<ProductorReadDto> productoresDestacados { get; set; } = new List<ProductorReadDto>();
    }
}
