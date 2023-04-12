using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Clase
    {
        public Clase()
        {
            EstudiantesClases = new HashSet<EstudiantesClase>();
        }

        public int IdClase { get; set; }
        public int IdAsignatura { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public string Codigo { get; set; } = null!;
        public string Modalidad { get; set; } = null!;

        public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
        public virtual Curso IdCursoNavigation { get; set; } = null!;
        public virtual Profesore IdProfesorNavigation { get; set; } = null!;
        public virtual ICollection<EstudiantesClase> EstudiantesClases { get; set; }
    }
}
