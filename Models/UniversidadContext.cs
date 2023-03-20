using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Universidad.Models
{
    public partial class UniversidadContext : DbContext
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

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignaturas_Areas");

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

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

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

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdPensum).HasColumnName("id_pensum");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamentos_Carreras");

                entity.HasOne(d => d.IdPensumNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdPensum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pensum_Carreras");
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

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.IdCuatrimestre).HasColumnName("id_cuatrimestre");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.TotalCreditos).HasColumnName("total_creditos");

                entity.HasOne(d => d.IdCuatrimestreNavigation)
                    .WithMany(p => p.Pensums)
                    .HasForeignKey(d => d.IdCuatrimestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuatrimestres_Pensum");
            });

            modelBuilder.Entity<PensumAsignatura>(entity =>
            {
                entity.ToTable("Pensum_Asignaturas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

                entity.Property(e => e.IdPensum).HasColumnName("id_pensum");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.PensumAsignaturas)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignaturas_Pensum_Asignaturas");

                entity.HasOne(d => d.IdPensumNavigation)
                    .WithMany(p => p.PensumAsignaturas)
                    .HasForeignKey(d => d.IdPensum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pensum_Pensum_Asignaturas");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

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

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesores_Areas");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
