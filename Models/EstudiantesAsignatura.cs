using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class EstudiantesAsignatura
    {
        public int Id { get; set; }
        public int IdEstudiantes { get; set; }
        public int IdAsignatura { get; set; }

        public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
        public virtual Estudiante IdEstudiantesNavigation { get; set; } = null!;
    }
}
