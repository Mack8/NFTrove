using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Tarjeta
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<VentaNft> VentaNft { get; set; } = new List<VentaNft>();
}
