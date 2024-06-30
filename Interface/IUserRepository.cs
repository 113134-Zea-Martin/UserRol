using UsuariosConRoles.Models;

namespace UsuariosConRoles.Interface
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetAllUser();
        Task<Usuario> GetUserById(Guid id);

    }
}
