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

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Nft> Nft { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<PropietarioNft> PropietarioNft { get; set; }

    public virtual DbSet<Tarjeta> Tarjeta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTE__3214EC27F53E3C28");

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

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleF__6E19D6FA866C3623");

            entity.Property(e => e.DetalleId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[NoFactura])")
                .HasColumnName("DetalleID");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Nftid).HasColumnName("NFTID");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalLinea).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFactura)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__DetalleFa__Factu__3E52440B");

            entity.HasOne(d => d.Nft).WithMany(p => p.DetalleFactura)
                .HasForeignKey(d => d.Nftid)
                .HasConstraintName("FK__DetalleFa__NFTID__3F466844");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__5C0248059E2F3F3F");

            entity.Property(e => e.FacturaId)
                .ValueGeneratedNever()
                .HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.TarjetaId).HasColumnName("TarjetaID");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Factura)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Factura__Cliente__398D8EEE");

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Factura)
                .HasForeignKey(d => d.TarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__Tarjeta__3A81B327");
        });

        modelBuilder.Entity<Nft>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NFT__3214EC274E31AC03");

            entity.ToTable("NFT");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAIS__3214EC27A5ADC352");

            entity.ToTable("PAIS");

            entity.HasIndex(e => e.Iso, "UQ__PAIS__C4979A23240A174D").IsUnique();

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
            entity.HasKey(e => e.Nftid).HasName("PK__PROPIETA__5A8CBD1A97F4B9C8");

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
            entity.HasKey(e => e.Id).HasName("PK__TARJETA__3214EC278DD99C72");

            entity.ToTable("TARJETA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });
        modelBuilder.HasSequence("NoFactura").HasMin(1L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
