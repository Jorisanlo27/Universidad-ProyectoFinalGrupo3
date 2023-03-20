using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            ProfesoresAreas = new HashSet<ProfesoresArea>();
        }

        public int IdProfesor { get; set; }
        public int IdPersona { get; set; }
        public int IdArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<ProfesoresArea> ProfesoresAreas { get; set; }
    }
}
