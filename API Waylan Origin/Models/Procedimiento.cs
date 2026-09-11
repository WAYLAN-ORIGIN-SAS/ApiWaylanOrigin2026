namespace API_Waylan_Origin.Models
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdProductor { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public Productor Productor { get; set; } = null!;
    }
}
