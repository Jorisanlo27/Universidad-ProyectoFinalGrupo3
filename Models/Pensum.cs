namespace Universidad.Models
{
	public partial class Pensum
    {
        public Pensum()
        {
            PensumAsignaturas = new HashSet<PensumAsignatura>();
        }

        public int IdPensum { get; set; }
        public int IdCarrera { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int TotalCreditos { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; } = null!;
        public virtual ICollection<PensumAsignatura> PensumAsignaturas { get; set; }
    }
}
