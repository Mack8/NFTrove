using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string NombreRol { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> UsuarioNavigation { get; set; } = new List<Usuario>();
}
