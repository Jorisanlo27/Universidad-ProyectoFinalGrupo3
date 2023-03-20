using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Pensum
    {
        public Pensum()
        {
            Carreras = new HashSet<Carrera>();
            PensumAsignaturas = new HashSet<PensumAsignatura>();
        }

        public int IdPensum { get; set; }
        public int IdCuatrimestre { get; set; }
        public int IdAsignatura { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int TotalCreditos { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Cuatrimestre IdCuatrimestreNavigation { get; set; } = null!;
        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<PensumAsignatura> PensumAsignaturas { get; set; }
    }
}
