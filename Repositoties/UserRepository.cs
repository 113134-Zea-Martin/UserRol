using Microsoft.EntityFrameworkCore;
using UsuariosConRoles.Data;
using UsuariosConRoles.Dtos;
using UsuariosConRoles.Interface;
using UsuariosConRoles.Models;

namespace UsuariosConRoles.Repositoties
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Usuario>> GetAllUser()
        {
           

            var users = await _context.Usuarios.Include(c =>c.IdRoleNavigation).ToListAsync();
         


            return users;
        }

        public Task<Usuario> GetUserById(Guid id)
        { 
            var user = _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
