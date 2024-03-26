using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NFTrove.Infraestructure.Models;

namespace NFTrove.Infraestructure.Data;

public partial class NFTroveContext : DbContext
{
    public NFTroveContext(DbContextOptions<NFTroveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Nft> Nft { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<PropietarioNft> PropietarioNft { get; set; }

    public virtual DbSet<Tarjeta> Tarjeta { get; set; }

    public virtual DbSet<VentaNft> VentaNft { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTE__3214EC27CED0055C");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaisId).HasColumnName("PaisID");

            entity.HasOne(d => d.Pais).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK__CLIENTE__PaisID__286302EC");
        });

        modelBuilder.Entity<Nft>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NFT__3214EC2796A44DDA");

            entity.ToTable("NFT");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAIS__3214EC272CD34596");

            entity.ToTable("PAIS");

            entity.HasIndex(e => e.Iso, "UQ__PAIS__C4979A239D19F069").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Iso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO");
        });

        modelBuilder.Entity<PropietarioNft>(entity =>
        {
            entity.HasKey(e => e.Nftid).HasName("PK__PROPIETA__5A8CBD1AF569B25C");

            entity.ToTable("PROPIETARIO_NFT");

            entity.Property(e => e.Nftid)
                .ValueGeneratedNever()
                .HasColumnName("NFTID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.PropietarioNft)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__PROPIETAR__Clien__30F848ED");

            entity.HasOne(d => d.Nft).WithOne(p => p.PropietarioNft)
                .HasForeignKey<PropietarioNft>(d => d.Nftid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROPIETAR__NFTID__300424B4");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TARJETA__3214EC27EB301CBF");

            entity.ToTable("TARJETA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VentaNft>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__VentaNFT__5B41514CE2990862");

            entity.ToTable("VentaNFT");

            entity.Property(e => e.VentaId)
                .ValueGeneratedNever()
                .HasColumnName("VentaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nftid).HasColumnName("NFTID");
            entity.Property(e => e.TarjetaId).HasColumnName("TarjetaID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.VentaNft)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__VentaNFT__Client__34C8D9D1");

            entity.HasOne(d => d.Nft).WithMany(p => p.VentaNft)
                .HasForeignKey(d => d.Nftid)
                .HasConstraintName("FK__VentaNFT__NFTID__33D4B598");

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.VentaNft)
                .HasForeignKey(d => d.TarjetaId)
                .HasConstraintName("FK__VentaNFT__Tarjet__35BCFE0A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
