using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngenieria.Models;

public partial class IngenieriaWebContext : DbContext
{
    public IngenieriaWebContext()
    {
    }

    public IngenieriaWebContext(DbContextOptions<IngenieriaWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Semestre> Semestres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ProOS10;Database=ProyectoIngenieriaWeb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Califica__3213E83F81E4CA2D");

            entity.HasOne(d => d.Semestre).WithMany(p => p.Calificacions).HasConstraintName("FK__Calificac__Semes__440B1D61");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3213E83FDF12F04D");

            entity.HasMany(d => d.Materia).WithMany(p => p.Estudiantes)
                .UsingEntity<Dictionary<string, object>>(
                    "EstudianteMaterium",
                    r => r.HasOne<Materium>().WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__Mater__4316F928"),
                    l => l.HasOne<Estudiante>().WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__Estud__4222D4EF"),
                    j =>
                    {
                        j.HasKey("EstudianteId", "MateriaId").HasName("PK__Estudian__6FA69AE01730F243");
                        j.ToTable("EstudianteMateria");
                        j.IndexerProperty<int>("EstudianteId").HasColumnName("EstudianteID");
                        j.IndexerProperty<int>("MateriaId").HasColumnName("MateriaID");
                    });
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materia__3213E83F2A57F7BA");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Materia).HasConstraintName("FK__Materia__Profeso__3F466844");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3213E83F8C6A5A6B");
        });

        modelBuilder.Entity<Semestre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semestre__3213E83FC8835D75");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
