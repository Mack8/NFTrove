using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Nft
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Autor { get; set; }

    public decimal? Valor { get; set; }

    public int? CantidadInventario { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    public virtual PropietarioNft? PropietarioNft { get; set; }
}
