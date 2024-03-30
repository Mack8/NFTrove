using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public Guid? ClienteId { get; set; }

    public DateOnly? FechaFactura { get; set; }

    public decimal? Total { get; set; }

    public int TarjetaId { get; set; }

    public int EstadoFactura { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    public virtual Tarjeta Tarjeta { get; set; } = null!;
}
