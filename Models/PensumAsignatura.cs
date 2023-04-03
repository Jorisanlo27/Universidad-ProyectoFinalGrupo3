namespace Universidad.Models
{
	public partial class PensumAsignatura
    {
        public int Id { get; set; }
        public int IdPensum { get; set; }
        public int IdCuatrimestre { get; set; }
        public int IdAsignatura { get; set; }

        public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
        public virtual Cuatrimestre IdCuatrimestreNavigation { get; set; } = null!;
        public virtual Pensum IdPensumNavigation { get; set; } = null!;
    }
}
