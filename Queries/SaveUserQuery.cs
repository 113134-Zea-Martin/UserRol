using UsuariosConRoles.Models;

namespace UsuariosConRoles.Queries
{
    public class SaveUserQuery
    {
        public Guid Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Email { get; set; }

        public Guid IdRole { get; set; }
        
    }
}
