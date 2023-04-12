using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Clases = new HashSet<Clase>();
            PensumAsignaturas = new HashSet<PensumAsignatura>();
        }

        public int IdAsignatura { get; set; }
        public int? IdArea { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Creditos { get; set; }
        public string? PreRequisitos { get; set; }
        public string? Metodo { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual ICollection<Clase> Clases { get; set; }
        public virtual ICollection<PensumAsignatura> PensumAsignaturas { get; set; }
    }
}
