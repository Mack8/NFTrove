using System;
using System.Collections.Generic;

namespace NFTrove.Infraestructure.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? RolId { get; set; }

    public virtual Rol? Rol { get; set; }

    public virtual ICollection<Rol> RolNavigation { get; set; } = new List<Rol>();
}
