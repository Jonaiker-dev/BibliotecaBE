using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBE.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<DetalleLibro> DetalleLibros { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VistaDetalle> VistaDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Idautor);

            entity.ToTable("autor");

            entity.Property(e => e.Idautor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idautor");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.NacionalidadNavigation).WithMany(p => p.Autors)
                .HasForeignKey(d => d.Nacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autor_nacionalidad");
        });

        modelBuilder.Entity<DetalleLibro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Detalle_Libro");

            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Idlibro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idlibro");
            entity.Property(e => e.Isbn)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Idestado);

            entity.ToTable("estado");

            entity.Property(e => e.Idestado).HasColumnName("idestado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Idlibro);

            entity.ToTable("libro");

            entity.HasIndex(e => e.Idlibro, "UK_ISBN").IsUnique();

            entity.Property(e => e.Idlibro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idlibro");
            entity.Property(e => e.Editorial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("editorial");
            entity.Property(e => e.Isbn)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.Portada)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("portada");
            entity.Property(e => e.Publicado).HasColumnName("publicado");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.StockVar).HasColumnName("stock_var");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasMany(d => d.Idautors).WithMany(p => p.Idlibros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibroAutor",
                    r => r.HasOne<Autor>().WithMany()
                        .HasForeignKey("Idautor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_libro_autor_autor"),
                    l => l.HasOne<Libro>().WithMany()
                        .HasForeignKey("Idlibro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_libro_autor_libro"),
                    j =>
                    {
                        j.HasKey("Idlibro", "Idautor");
                        j.ToTable("libro_autor");
                        j.IndexerProperty<string>("Idlibro")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("idlibro");
                        j.IndexerProperty<string>("Idautor")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("idautor");
                    });
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidad);

            entity.ToTable("nacionalidad");

            entity.Property(e => e.IdNacionalidad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nacionalidad1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nacionalidad");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Idprestamo);

            entity.ToTable("prestamo");

            entity.Property(e => e.Idprestamo).HasColumnName("idprestamo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaDevolucion).HasColumnName("fecha_devolucion");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.Idlibro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idlibro");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prestamo_estado");

            entity.HasOne(d => d.IdlibroNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Idlibro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prestamo_libro");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prestamo_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario);

            entity.ToTable("usuario");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<VistaDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vista_Detalles");

            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dni");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaDevolucion).HasColumnName("fecha_devolucion");
            entity.Property(e => e.Idlibro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idlibro");
            entity.Property(e => e.Idprestamo).HasColumnName("idprestamo");
            entity.Property(e => e.Isbn)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.StockVar).HasColumnName("stock_var");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
