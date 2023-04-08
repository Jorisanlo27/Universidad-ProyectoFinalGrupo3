namespace Universidad.Models
{
	public partial class EstudiantesClase
    {
        public int Id { get; set; }
        public int IdEstudiantes { get; set; }
        public int IdClase { get; set; }

        public virtual Clase IdClaseNavigation { get; set; } = null!;
        public virtual Estudiante IdEstudiantesNavigation { get; set; } = null!;
    }
}
