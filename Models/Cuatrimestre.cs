namespace Universidad.Models
{
	public partial class Cuatrimestre
    {
        public Cuatrimestre()
        {
            Calificaciones = new HashSet<Calificacione>();
            PensumAsignaturas = new HashSet<PensumAsignatura>();
        }

        public int IdCuatrimestre { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<PensumAsignatura> PensumAsignaturas { get; set; }
    }
}
