using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Estudiantes = new HashSet<Estudiante>();
            Profesores = new HashSet<Profesore>();
        }

        public int IdPersona { get; set; }
        public string Matricula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public string Cedula { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? NumCelular { get; set; }
        public string? NumTelefono { get; set; }
        public string Direccion { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
    }
}
