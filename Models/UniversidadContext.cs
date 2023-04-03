using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Universidad.Models
{
	public partial class UniversidadContext : IdentityDbContext
	{
        public UniversidadContext()
        {
        }

        public UniversidadContext(DbContextOptions<UniversidadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;
        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Cuatrimestre> Cuatrimestres { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<EstudiantesAsignatura> EstudiantesAsignaturas { get; set; } = null!;
        public virtual DbSet<Pensum> Pensums { get; set; } = null!;
        public virtual DbSet<PensumAsignatura> PensumAsignaturas { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;
        public virtual DbSet<ProfesoresArea> ProfesoresAreas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3FJ5SES\\APDB;Database=Universidad;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamentos_Areas");
            });

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura);

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .HasColumnName("codigo");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.Metodo)
                    .HasMaxLength(50)
                    .HasColumnName("metodo");

                entity.Property(e => e.Modalidad)
                    .HasMaxLength(50)
                    .HasColumnName("modalidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.PreRequisitos)
                    .HasMaxLength(50)
                    .HasColumnName("pre_requisitos");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignaturas_Cursos");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profesores_Asignaturas");
            });

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.IdCalificaciones);

                entity.Property(e => e.IdCalificaciones).HasColumnName("id_calificaciones");

                entity.Property(e => e.ExamenFinal).HasColumnName("examen_final");

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.IdCuatrimestre).HasColumnName("id_cuatrimestre");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.LetraFinal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("letra_final")
                    .IsFixedLength();

                entity.Property(e => e.PrimerParcial).HasColumnName("primer_parcial");

                entity.Property(e => e.SegundoParcial).HasColumnName("segundo_parcial");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignaturas_Calificaciones");

                entity.HasOne(d => d.IdCuatrimestreNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdCuatrimestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuatrimestres_Calificaciones");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Calificaciones");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera);

                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamentos_Carreras");
            });

            modelBuilder.Entity<Cuatrimestre>(entity =>
            {
                entity.HasKey(e => e.IdCuatrimestre)
                    .HasName("PK_Cuatrimestre");

                entity.Property(e => e.IdCuatrimestre).HasColumnName("id_cuatrimestre");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fecha_final");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.Edificio).HasColumnName("edificio");

                entity.Property(e => e.MaxCapacidad).HasColumnName("max_capacidad");

                entity.Property(e => e.NumAula).HasColumnName("num_aula");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiantes);

                entity.Property(e => e.IdEstudiantes).HasColumnName("id_estudiantes");

                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carreras_Estudiantes");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Estudiantes");
            });

            modelBuilder.Entity<EstudiantesAsignatura>(entity =>
            {
                entity.ToTable("Estudiantes_Asignaturas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.IdEstudiantes).HasColumnName("id_estudiantes");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.EstudiantesAsignaturas)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignaturas_Estudiantes_Asignaturas");

                entity.HasOne(d => d.IdEstudiantesNavigation)
                    .WithMany(p => p.EstudiantesAsignaturas)
                    .HasForeignKey(d => d.IdEstudiantes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Estudiantes_Asignaturas");
            });

            modelBuilder.Entity<Pensum>(entity =>
            {
                entity.HasKey(e => e.IdPensum);

                entity.ToTable("Pensum");

                entity.Property(e => e.IdPensum).HasColumnName("id_pensum");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .HasColumnName("codigo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.TotalCreditos).HasColumnName("total_creditos");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Pensums)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carreras_Pensum");
            });

            modelBuilder.Entity<PensumAsignatura>(entity =>
            {
                entity.ToTable("Pensum_Asignaturas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.IdCuatrimestre).HasColumnName("id_cuatrimestre");

                entity.Property(e => e.IdPensum).HasColumnName("id_pensum");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.PensumAsignaturas)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignaturas_Pensum_Asignaturas");

                entity.HasOne(d => d.IdCuatrimestreNavigation)
                    .WithMany(p => p.PensumAsignaturas)
                    .HasForeignKey(d => d.IdCuatrimestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuatrimestres_Pensum_Asignaturas");

                entity.HasOne(d => d.IdPensumNavigation)
                    .WithMany(p => p.PensumAsignaturas)
                    .HasForeignKey(d => d.IdPensum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pensum_Pensum_Asignaturas");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.HasIndex(e => e.Matricula, "UQ__Personas__30962D15BA14AD61")
                    .IsUnique();

                entity.HasIndex(e => e.Cedula, "UQ__Personas__415B7BE53B00BCC9")
                    .IsUnique();

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .HasColumnName("cedula");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion).HasColumnName("direccion");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .HasColumnName("genero")
                    .IsFixedLength();

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .HasColumnName("matricula");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumCelular)
                    .HasMaxLength(30)
                    .HasColumnName("num_celular");

                entity.Property(e => e.NumTelefono)
                    .HasMaxLength(30)
                    .HasColumnName("num_telefono");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Profesores");
            });

            modelBuilder.Entity<ProfesoresArea>(entity =>
            {
                entity.ToTable("Profesores_Areas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.ProfesoresAreas)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_Areas_Profesores_Areas");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.ProfesoresAreas)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_Profesores_Profesores_Areas");
            });

			modelBuilder
	.HasAnnotation("ProductVersion", "3.0.0")
	.HasAnnotation("Relational:MaxIdentifierLength", 128)
	.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
			{
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("ConcurrencyStamp")
					.IsConcurrencyToken()
					.HasColumnType("nvarchar(max)");

				b.Property<string>("Name")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<string>("NormalizedName")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.HasKey("Id");

				b.HasIndex("NormalizedName")
					.IsUnique()
					.HasName("RoleNameIndex")
					.HasFilter("[NormalizedName] IS NOT NULL");

				b.ToTable("AspNetRoles");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("ClaimType")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("ClaimValue")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("RoleId")
					.IsRequired()
					.HasColumnType("nvarchar(450)");

				b.HasKey("Id");

				b.HasIndex("RoleId");

				b.ToTable("AspNetRoleClaims");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
			{
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<int>("AccessFailedCount")
					.HasColumnType("int");

				b.Property<string>("ConcurrencyStamp")
					.IsConcurrencyToken()
					.HasColumnType("nvarchar(max)");

				b.Property<string>("Email")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<bool>("EmailConfirmed")
					.HasColumnType("bit");

				b.Property<bool>("LockoutEnabled")
					.HasColumnType("bit");

				b.Property<DateTimeOffset?>("LockoutEnd")
					.HasColumnType("datetimeoffset");

				b.Property<string>("NormalizedEmail")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<string>("NormalizedUserName")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<string>("PasswordHash")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("PhoneNumber")
					.HasColumnType("nvarchar(max)");

				b.Property<bool>("PhoneNumberConfirmed")
					.HasColumnType("bit");

				b.Property<string>("SecurityStamp")
					.HasColumnType("nvarchar(max)");

				b.Property<bool>("TwoFactorEnabled")
					.HasColumnType("bit");

				b.Property<string>("UserName")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.HasKey("Id");

				b.HasIndex("NormalizedEmail")
					.HasName("EmailIndex");

				b.HasIndex("NormalizedUserName")
					.IsUnique()
					.HasName("UserNameIndex")
					.HasFilter("[NormalizedUserName] IS NOT NULL");

				b.ToTable("AspNetUsers");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("ClaimType")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("ClaimValue")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("UserId")
					.IsRequired()
					.HasColumnType("nvarchar(450)");

				b.HasKey("Id");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserClaims");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
			{
				b.Property<string>("LoginProvider")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("ProviderKey")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("ProviderDisplayName")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("UserId")
					.IsRequired()
					.HasColumnType("nvarchar(450)");

				b.HasKey("LoginProvider", "ProviderKey");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserLogins");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
			{
				b.Property<string>("UserId")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("RoleId")
					.HasColumnType("nvarchar(450)");

				b.HasKey("UserId", "RoleId");

				b.HasIndex("RoleId");

				b.ToTable("AspNetUserRoles");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
			{
				b.Property<string>("UserId")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("LoginProvider")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("Name")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("Value")
					.HasColumnType("nvarchar(max)");

				b.HasKey("UserId", "LoginProvider", "Name");

				b.ToTable("AspNetUserTokens");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
					.WithMany()
					.HasForeignKey("RoleId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
					.WithMany()
					.HasForeignKey("RoleId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
