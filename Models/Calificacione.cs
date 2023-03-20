using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Calificacione
    {
        public int IdCalificaciones { get; set; }
        public int IdCuatrimestre { get; set; }
        public int IdEstudiante { get; set; }
        public int IdAsignatura { get; set; }
        public int? PrimerParcial { get; set; }
        public int? SegundoParcial { get; set; }
        public int? ExamenFinal { get; set; }
        public string? LetraFinal { get; set; }

        public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
        public virtual Cuatrimestre IdCuatrimestreNavigation { get; set; } = null!;
        public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
    }
}
