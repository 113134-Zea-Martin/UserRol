using System;
using System.Collections.Generic;

namespace UsuariosConRoles.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string NombreRol { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
