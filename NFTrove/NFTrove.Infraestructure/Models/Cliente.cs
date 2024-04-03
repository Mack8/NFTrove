using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Identificacion { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? PaisId { get; set; }

    public virtual ICollection<EncabezadoFactura> EncabezadoFactura { get; set; } = new List<EncabezadoFactura>();

    public virtual Pais? Pais { get; set; }

    public virtual ICollection<PropietarioNft> PropietarioNft { get; set; } = new List<PropietarioNft>();
}
