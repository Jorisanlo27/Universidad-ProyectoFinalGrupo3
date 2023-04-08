namespace Universidad.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Clases = new HashSet<Clase>();
            PensumAsignaturas = new HashSet<PensumAsignatura>();
        }

        public int IdAsignatura { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Creditos { get; set; }
        public string? PreRequisitos { get; set; }
        public string Modalidad { get; set; } = null!;
        public string Metodo { get; set; } = null!;

        public virtual ICollection<Clase> Clases { get; set; }
        public virtual ICollection<PensumAsignatura> PensumAsignaturas { get; set; }
    }
}
