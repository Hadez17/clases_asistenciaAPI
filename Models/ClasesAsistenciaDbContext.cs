using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace clases_asistenciaAPI.Models;

public partial class ClasesAsistenciaDbContext : DbContext
{
    public ClasesAsistenciaDbContext()
    {
    }

    public ClasesAsistenciaDbContext(DbContextOptions<ClasesAsistenciaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencia { get; set; }

    public virtual DbSet<Clases> Clases { get; set; }

    public virtual DbSet<Estudiantes> Estudiantes { get; set; }

    public virtual DbSet<ReportesAsistencia> ReportesAsistencia { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ\\SQLEXPRESS; Database=clases_asistenciaDb; User Id=sa; Password=kevin; Encrypt=False; TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.AsistenciaId).HasName("PK__asistenc__10181088EA264C33");

            entity.ToTable("asistencia");

            entity.Property(e => e.AsistenciaId).HasColumnName("asistencia_id");
            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");

            entity.HasOne(d => d.Clase).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.ClaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__asistenci__clase__5535A963");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__asistenci__estud__5441852A");
        });

        modelBuilder.Entity<Clases>(entity =>
        {
            entity.HasKey(e => e.ClaseId).HasName("PK__clases__E6D3E3528BD56FDE");

            entity.ToTable("clases");

            entity.HasIndex(e => e.ClaseNombre, "UQ__clases__08A6D9D0761292F5").IsUnique();

            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.ClaseDescripcion)
                .HasColumnType("text")
                .HasColumnName("clase_descripcion");
            entity.Property(e => e.ClaseNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clase_nombre");
            entity.Property(e => e.Horario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("horario");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Clases)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__clases__usuario___4D94879B");
        });

        modelBuilder.Entity<Estudiantes>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PK__estudian__A2390029832F55AD");

            entity.ToTable("estudiantes");

            entity.HasIndex(e => e.EstudianteNombre, "UQ__estudian__EC2739ECA2621C86").IsUnique();

            entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");
            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.EstudianteApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estudiante_apellido");
            entity.Property(e => e.EstudianteNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estudiante_nombre");

            entity.HasOne(d => d.Clase).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.ClaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estudiant__clase__5165187F");
        });

        modelBuilder.Entity<ReportesAsistencia>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PK__reportes__375E052CC0D29B96");

            entity.ToTable("reportes_asistencia");

            entity.Property(e => e.ReporteId).HasColumnName("reporte_id");
            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.TotalAsistencias).HasColumnName("total_asistencias");
            entity.Property(e => e.TotalAusencias).HasColumnName("total_ausencias");

            entity.HasOne(d => d.Clase).WithMany(p => p.ReportesAsistencia)
                .HasForeignKey(d => d.ClaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___clase__59063A47");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.ReportesAsistencia)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___estud__5812160E");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__usuarios__2ED7D2AFA0FBBFDD");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.UsuarioNombre, "UQ__usuarios__220D44A24BBA42E8").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.UsuarioNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario_nombre");
            entity.Property(e => e.UsuarioPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario_password");
            entity.Property(e => e.UsuarioRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
