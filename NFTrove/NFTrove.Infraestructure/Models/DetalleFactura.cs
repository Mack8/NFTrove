using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class DetalleFactura
{
    public int DetalleId { get; set; }

    public int? FacturaId { get; set; }

    public Guid? Nftid { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? TotalLinea { get; set; }

    public int? EstadoFactura { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Nft? Nft { get; set; }
}
