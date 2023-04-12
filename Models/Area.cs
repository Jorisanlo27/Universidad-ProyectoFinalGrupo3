using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Area
    {
        public Area()
        {
            Asignaturas = new HashSet<Asignatura>();
            Carreras = new HashSet<Carrera>();
            ProfesoresAreas = new HashSet<ProfesoresArea>();
        }

        public int IdArea { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<ProfesoresArea> ProfesoresAreas { get; set; }
    }
}
