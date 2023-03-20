using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Areas = new HashSet<Area>();
            Calificaciones = new HashSet<Calificacione>();
            EstudiantesAsignaturas = new HashSet<EstudiantesAsignatura>();
            PensumAsignaturas = new HashSet<PensumAsignatura>();
        }

        public int IdAsignatura { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Creditos { get; set; }
        public string? PreRequisitos { get; set; }
        public string Modalidad { get; set; } = null!;
        public string Metodo { get; set; } = null!;

        public virtual Curso IdCursoNavigation { get; set; } = null!;
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<EstudiantesAsignatura> EstudiantesAsignaturas { get; set; }
        public virtual ICollection<PensumAsignatura> PensumAsignaturas { get; set; }
    }
}
