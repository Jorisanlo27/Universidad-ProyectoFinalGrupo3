namespace Universidad.Models
{
	public partial class Profesore
    {
        public Profesore()
        {
            Asignaturas = new HashSet<Asignatura>();
            ProfesoresAreas = new HashSet<ProfesoresArea>();
        }

        public int IdProfesor { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
        public virtual ICollection<ProfesoresArea> ProfesoresAreas { get; set; }
    }
}
