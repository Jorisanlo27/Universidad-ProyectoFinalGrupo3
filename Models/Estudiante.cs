using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudiantesClases = new HashSet<EstudiantesClase>();
        }

        public int IdEstudiantes { get; set; }
        public int IdPersona { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<EstudiantesClase> EstudiantesClases { get; set; }
    }
}
