namespace UsuariosConRoles.Dtos
{
    public class UsuarioDto
    {
        public string NombreUsuario { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Guid IdRole { get; set; }

    }
}
