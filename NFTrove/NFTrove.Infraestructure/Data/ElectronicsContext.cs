using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NFTrove.Infraestructure.Models;

namespace NFTrove.Infraestructure.Data;

public partial class ElectronicsContext : DbContext
{
    public ElectronicsContext(DbContextOptions<ElectronicsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Nft> Nft { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<PropietarioNft> PropietarioNft { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Tarjeta> Tarjeta { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTE__3214EC27D859FFEA");

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
                .HasConstraintName("FK__CLIENTE__PaisID__4316F928");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleF__6E19D6FAA11F3E08");

            entity.Property(e => e.DetalleId)
                .HasDefaultValueSql("(NEXT VALUE FOR [NoFactura])")
                .HasColumnName("DetalleID");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Nftid).HasColumnName("NFTID");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalLinea).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFactura)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__DetalleFa__Factu__5441852A");

            entity.HasOne(d => d.Nft).WithMany(p => p.DetalleFactura)
                .HasForeignKey(d => d.Nftid)
                .HasConstraintName("FK__DetalleFa__NFTID__5535A963");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__5C024805FCA8281E");

            entity.Property(e => e.FacturaId)
                .ValueGeneratedNever()
                .HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.TarjetaId).HasColumnName("TarjetaID");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Factura)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Factura__Cliente__4E88ABD4");

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Factura)
                .HasForeignKey(d => d.TarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__Tarjeta__4F7CD00D");
        });

        modelBuilder.Entity<Nft>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NFT__3214EC27B18E20A2");

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
            entity.HasKey(e => e.Id).HasName("PK__PAIS__3214EC2740E01CA7");

            entity.ToTable("PAIS");

            entity.HasIndex(e => e.Iso, "UQ__PAIS__C4979A235ADB055A").IsUnique();

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
            entity.HasKey(e => e.Nftid).HasName("PK__PROPIETA__5A8CBD1AA1C3DEA7");

            entity.ToTable("PROPIETARIO_NFT");

            entity.Property(e => e.Nftid)
                .ValueGeneratedNever()
                .HasColumnName("NFTID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.PropietarioNft)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__PROPIETAR__Clien__4BAC3F29");

            entity.HasOne(d => d.Nft).WithOne(p => p.PropietarioNft)
                .HasForeignKey<PropietarioNft>(d => d.Nftid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROPIETAR__NFTID__4AB81AF0");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC27E3B5110D");

            entity.HasIndex(e => e.NombreRol, "UQ__Rol__4F0B537F4BCD542C").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TARJETA__3214EC273B434DFB");

            entity.ToTable("TARJETA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC2799330340");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuario__531402F3C1944D41").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuario__6B0F5AE0123E4E3B").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuario__RolID__3C69FB99");

            entity.HasMany(d => d.RolNavigation).WithMany(p => p.UsuarioNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioRo__RolID__59063A47"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioRo__Usuar__5812160E"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RolId").HasName("PK__UsuarioR__24AFD7B5A9F240D5");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("UsuarioID");
                        j.IndexerProperty<int>("RolId").HasColumnName("RolID");
                    });
        });
        modelBuilder.HasSequence("NoFactura");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
