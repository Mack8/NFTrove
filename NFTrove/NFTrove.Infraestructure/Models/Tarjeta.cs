using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Tarjeta
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<EncabezadoFactura> Encabezadofactura { get; set; } = new List<EncabezadoFactura>();
}
