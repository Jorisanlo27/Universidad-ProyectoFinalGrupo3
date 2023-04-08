namespace Universidad.Models
{
	public partial class Clase
    {
        public Clase()
        {
            Calificaciones = new HashSet<Calificacione>();
            EstudiantesClases = new HashSet<EstudiantesClase>();
        }

        public int IdClase { get; set; }
        public int IdAsignatura { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public string Codigo { get; set; }

        public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
        public virtual Curso IdCursoNavigation { get; set; } = null!;
        public virtual Profesore IdProfesorNavigation { get; set; } = null!;
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<EstudiantesClase> EstudiantesClases { get; set; }
    }
}
