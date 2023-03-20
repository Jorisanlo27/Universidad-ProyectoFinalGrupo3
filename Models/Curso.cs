﻿using System;
using System.Collections.Generic;

namespace Universidad.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Asignaturas = new HashSet<Asignatura>();
        }

        public int IdCurso { get; set; }
        public int Edificio { get; set; }
        public int NumAula { get; set; }
        public int? MaxCapacidad { get; set; }

        public virtual ICollection<Asignatura> Asignaturas { get; set; }
    }
}
