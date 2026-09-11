namespace API_Waylan_Origin.Models
{
    public class Organizacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ImagenLogo { get; set; } = string.Empty;
        public string ImagenHero { get; set; } = string.Empty;
        public string Descripcion1 { get; set; } = string.Empty;
        public string Descripcion2 { get; set; } = string.Empty;
        public string Enfoque { get; set; } = string.Empty;

        public ICollection<Productor> productores { get; set; } = new HashSet<Productor>();

    }
}
