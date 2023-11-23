using DexteraTech.CarStore.Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DexteraTech.CarStore.Web.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cambio> Cambios { get; set; }

    public virtual DbSet<Carroceria> Carroceria { get; set; }

    public virtual DbSet<Cor> Cores { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }
    public virtual DbSet<Veiculo> Veiculos { get; set; }

    public virtual DbSet<Versao> Versaos { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=TopGearProject;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cambio>(entity =>
        {
            entity.HasKey(e => e.IdCambio).HasName("PK_IdCambio");

            entity.ToTable("Cambio");

            entity.Property(e => e.IdCambio).ValueGeneratedOnAdd();
            entity.Property(e => e.NmCambio)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Carroceria>(entity =>
        {
            entity.HasKey(e => e.IdCarroceria).HasName("PK_IdCarroceria");

            entity.Property(e => e.IdCarroceria).ValueGeneratedOnAdd();
            entity.Property(e => e.NmCarroceria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cor>(entity =>
        {
            entity.HasKey(e => e.IdCor).HasName("PK_IdCor");

            entity.ToTable("Cor");

            entity.Property(e => e.IdCor).ValueGeneratedOnAdd();
            entity.Property(e => e.NmCor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK_IdMarca");

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarca).ValueGeneratedOnAdd();
            entity.Property(e => e.NmMarca)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK_IdModelo");

            entity.ToTable("Modelo");

            entity.HasIndex(e => e.IdCarroceria, "FK_IdCarroceria");

            entity.HasIndex(e => e.IdMarca, "FK_IdModelo");

            entity.Property(e => e.IdModelo).ValueGeneratedOnAdd();
            entity.Property(e => e.NmModelo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCarroceriaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdCarroceria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carroceria_Modelo");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Marca_Modelo");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.IdVeiculo).HasName("PK_IdVeiculo");

            entity.ToTable("Veiculo");

            entity.HasIndex(e => e.IdCor, "FK_IdAno");

            entity.HasIndex(e => e.IdVersao, "FK_IdCambio");

            entity.HasIndex(e => e.IdCambio, "FK_IdCor");

            entity.Property(e => e.IdVeiculo).ValueGeneratedOnAdd();
            entity.Property(e => e.Ipva).HasColumnName("IPVA");
            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCambioNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdCambio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cambio_Veiculo");

            entity.HasOne(d => d.IdCorNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdCor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cor_Veiculo");

            entity.HasOne(d => d.IdVersaoNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdVersao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Versao_Veiculo");

            entity.HasMany(d => d.Fotos)
                .WithOne(f => f.IdVeiculoNavigation)
                .HasForeignKey(d => d.IdFoto)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("FK_Foto_Veiculo");
        });

        modelBuilder.Entity<Versao>(entity =>
        {
            entity.HasKey(e => e.IdVersao).HasName("PK_IdVersao");

            entity.ToTable("Versao");

            entity.HasIndex(e => e.IdModelo, "FK_IdModelo");

            entity.Property(e => e.IdVersao).ValueGeneratedOnAdd();
            entity.Property(e => e.NmVersao)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Versaos)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modelo_Versao");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.IdFoto).HasName("PK_IdFoto");

            entity.ToTable("Foto");

            entity.Property(e => e.IdFoto).ValueGeneratedOnAdd();
            entity.Property(e => e.NmArquivo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Imagen)
                .HasColumnType("varbinary(max)");

            entity.HasOne(d => d.IdVeiculoNavigation).WithMany(v => v.Fotos)
                .HasForeignKey(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Veiculo_Foto");
        });


        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}