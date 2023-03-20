using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Calificaciones = new HashSet<Calificacione>();
            EstudiantesAsignaturas = new HashSet<EstudiantesAsignatura>();
        }

        public int IdEstudiantes { get; set; }
        public int IdPersona { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<EstudiantesAsignatura> EstudiantesAsignaturas { get; set; }
    }
}
