using AutoMapper;
using UsuariosConRoles.Dtos;
using UsuariosConRoles.Models;

namespace UsuariosConRoles.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
              CreateMap<Usuario,UsuarioDto>();
              
              CreateMap<Role, RoleDto>();
        }
    }
}
