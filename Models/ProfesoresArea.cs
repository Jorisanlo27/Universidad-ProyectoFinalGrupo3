using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class ProfesoresArea
    {
        public int Id { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdArea { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual Profesore? IdProfesorNavigation { get; set; }
    }
}
