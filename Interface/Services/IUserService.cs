using UsuariosConRoles.Dtos;
using UsuariosConRoles.Response;

namespace UsuariosConRoles.Interface.Services
{
    public interface IUserService
    {
        Task<ResponseApi<List<UsuarioDto>>> GetAllUser();

        Task<ResponseApi<UsuarioDto>> GetUserById(Guid id);
    }
}
