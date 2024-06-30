using System;
using System.Collections.Generic;

namespace UsuariosConRoles.Models;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
