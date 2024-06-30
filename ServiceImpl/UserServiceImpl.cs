using AutoMapper;
using UsuariosConRoles.Dtos;
using UsuariosConRoles.Interface;
using UsuariosConRoles.Interface.Services;
using UsuariosConRoles.Response;

namespace UsuariosConRoles.ServiceImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServiceImpl(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ResponseApi<List<UsuarioDto>>> GetAllUser()
        {
            var response = new ResponseApi<List<UsuarioDto>>();

            var users = await _userRepository.GetAllUser();
            if(users != null && users.Count > 0)
            {
                
                response.Data = _mapper.Map<List<UsuarioDto>>(users);
                response.Success = true;
                return response;
            }
            else
            {
                response.ErrorMessage = "No se encontraron usuarios";
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseApi<UsuarioDto>> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if(user != null)
            {
                var userDto = new UsuarioDto
                { 
                    NombreUsuario = user.NombreUsuario,
                    Email = user.Email,
                    IdRole = user.IdRole,
                };
                return new ResponseApi<UsuarioDto>
                {
                    Data = userDto,
                    Success = true
                };

            }
            else
            {
                var response = new ResponseApi<UsuarioDto>();
                response.ErrorMessage = "No se encontro el usuario";
                response.Success = false;
                return response;
            }
        }
    }
}
