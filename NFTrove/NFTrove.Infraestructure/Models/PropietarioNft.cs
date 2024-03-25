using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class PropietarioNft
{
    public Guid Nftid { get; set; }

    public Guid? ClienteId { get; set; }

    public DateOnly? FechaAdquisicion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Nft Nft { get; set; } = null!;
}
