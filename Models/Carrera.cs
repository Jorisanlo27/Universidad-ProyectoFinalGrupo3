namespace Universidad.Models
{
	public partial class Carrera
    {
        public Carrera()
        {
            Estudiantes = new HashSet<Estudiante>();
            Pensums = new HashSet<Pensum>();
        }

        public int IdCarrera { get; set; }
        public int IdArea { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual Area IdAreaNavigation { get; set; } = null!;
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Pensum> Pensums { get; set; }
    }
}
