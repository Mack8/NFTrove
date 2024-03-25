using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class VentaNft
{
    public int VentaId { get; set; }

    public Guid? Nftid { get; set; }

    public Guid? ClienteId { get; set; }

    public int? TarjetaId { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Nft? Nft { get; set; }

    public virtual Tarjeta? Tarjeta { get; set; }
}
