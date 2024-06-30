using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using UsuariosConRoles.Data;
using UsuariosConRoles.Interface;
using UsuariosConRoles.Interface.Services;
using UsuariosConRoles.Models;
using UsuariosConRoles.Queries;

namespace UsuariosConRoles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;


        public UsersController(ApplicationContext context, IUserService service,IUserRepository userRepository)
        {
            _context = context;
            _userService = service;
            _userRepository = userRepository;
        }

        [HttpGet("/Users/GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }

        [HttpGet("/Users/GetById/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("/SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody] SaveUserQuery query)
        {
            if(query.Email == "" || query.NombreUsuario == "")
            {
                return BadRequest("El email y el nombre de usuario son requeridos");
            }

            var existe = _context.Usuarios.Any(u => u.Email == query.Email);

            if (existe)
            {
                return BadRequest("El Usuario ya existe");
            }

            var newUser = new Usuario
            {
                //cuando hago el post me genera solo el guid por lo que no es necesario pasarlo en el post
                Id = Guid.NewGuid(),
                Email = query.Email,
                NombreUsuario = query.NombreUsuario,
                IdRole = query.IdRole,
               

            };
            await _context.Usuarios.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut("/UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] SaveUserQuery query)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == query.Id);

            if (user == null)
            {
                return BadRequest("El usuario no existe");
            }

            user.Email = query.Email;
            user.NombreUsuario = query.NombreUsuario;
            user.IdRole = query.IdRole;

            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return BadRequest("El usuario no existe");
            }

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Usuario eliminado");
        }

    }
}
