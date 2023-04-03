﻿namespace Universidad.Models
{
	public partial class Departamento
    {
        public Departamento()
        {
            Areas = new HashSet<Area>();
        }

        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Area> Areas { get; set; }
    }
}
