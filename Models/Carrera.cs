using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdCarrera { get; set; }
        public int IdPensum { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
        public virtual Pensum IdPensumNavigation { get; set; } = null!;
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
