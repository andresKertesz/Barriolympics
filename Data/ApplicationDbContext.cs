using System;
using System.Collections.Generic;
using BarriolympicsRadzen.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BarriolympicsRadzen.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barriero> Barrieros { get; set; }

    public virtual DbSet<Competencium> Competencia { get; set; }

    public virtual DbSet<Copa> Copas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<ImagenesJuego> ImagenesJuegos { get; set; }

    public virtual DbSet<Juego> Juegos { get; set; }

    public virtual DbSet<TipoCompetencium> TipoCompetencia { get; set; }

    public virtual DbSet<TipoCopa> TipoCopas { get; set; }

    public virtual DbSet<TipoJuego> TipoJuegos { get; set; }

    public virtual DbSet<TokenLogin> TokenLogins { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barriero>(entity =>
        {
            entity.ToTable("Barriero");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Alias)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.FormatoNombre)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FraseCelebre)
                .IsRequired()
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasDefaultValue("No tiene.");
            entity.Property(e => e.Icon)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Competencium>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Imagen)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Competencia)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Competencia_TipoCompetencia");
        });

        modelBuilder.Entity<Copa>(entity =>
        {
            entity.ToTable("Copa");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Imagen)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Barriero).WithMany(p => p.Copas)
                .HasForeignKey(d => d.BarrieroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Copa_Barriero");

            entity.HasOne(d => d.Evento).WithMany(p => p.Copas)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("FK_Copa_Evento");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Copas)
                .HasForeignKey(d => d.TipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Copa_TipoCopa");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.ToTable("Evento");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("Event");

            entity.HasOne(d => d.Competencia).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CompetenciaId)
                .HasConstraintName("FK_Evento_Competencia");

            entity.HasOne(d => d.Juego).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.JuegoId)
                .HasConstraintName("FK_Evento_Juego");
        });

        modelBuilder.Entity<ImagenesJuego>(entity =>
        {
            entity.ToTable("ImagenesJuego");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Juego).WithMany(p => p.ImagenesJuegos)
                .HasForeignKey(d => d.JuegoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImagenesJuego_Juego");
        });

        modelBuilder.Entity<Juego>(entity =>
        {
            entity.ToTable("Juego");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.Link)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Juego_TipoJuego");
        });

        modelBuilder.Entity<TipoCompetencium>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Icon)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoCopa>(entity =>
        {
            entity.ToTable("TipoCopa");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Imagen)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoJuego>(entity =>
        {
            entity.ToTable("TipoJuego");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.Icon)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TokenLogin>(entity =>
        {
            entity.ToTable("TokenLogin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ValidoDesde).HasColumnType("datetime");
            entity.Property(e => e.ValidoHasta).HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TokenLogins)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TokenLogin_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Icon)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
