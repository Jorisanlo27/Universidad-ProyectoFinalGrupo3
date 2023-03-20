using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Cuatrimestre
    {
        public Cuatrimestre()
        {
            Calificaciones = new HashSet<Calificacione>();
            Pensums = new HashSet<Pensum>();
        }

        public int IdCuatrimestre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<Pensum> Pensums { get; set; }
    }
}
