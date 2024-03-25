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

    public string? ImagenUrl { get; set; }

    public virtual PropietarioNft? PropietarioNft { get; set; }

    public virtual ICollection<VentaNft> VentaNft { get; set; } = new List<VentaNft>();
}
