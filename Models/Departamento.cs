using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Areas = new HashSet<Area>();
            Carreras = new HashSet<Carrera>();
        }

        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
