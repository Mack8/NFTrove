using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Pais
{
    public int Id { get; set; }

    public string? Iso { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();
}
