using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Area
    {
        public Area()
        {
            Profesores = new HashSet<Profesore>();
            ProfesoresAreas = new HashSet<ProfesoresArea>();
        }

        public int IdArea { get; set; }
        public int IdDepartamento { get; set; }
        public int IdAsignatura { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual ICollection<Profesore> Profesores { get; set; }
        public virtual ICollection<ProfesoresArea> ProfesoresAreas { get; set; }
    }
}
