using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get() => Ok(BarberiaDataStore.Usuarios);

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var u = BarberiaDataStore.Usuarios.FirstOrDefault(x => x.Id == id);
            return u is null ? NotFound() : Ok(u);
        }

        [HttpPost]
        public ActionResult<Usuario> Post(Usuario usuario)
        {
            usuario.Id = BarberiaDataStore.Usuarios.Max(x => x.Id) + 1;
            BarberiaDataStore.Usuarios.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario update)
        {
            var u = BarberiaDataStore.Usuarios.FirstOrDefault(x => x.Id == id);
            if (u is null) return NotFound();
            u.NombreUsuario = update.NombreUsuario;
            u.Contrasena = update.Contrasena;
            u.RolId = update.RolId;
            u.Nombre = update.Nombre;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var u = BarberiaDataStore.Usuarios.FirstOrDefault(x => x.Id == id);
            if (u is null) return NotFound();
            BarberiaDataStore.Usuarios.Remove(u);
            return NoContent();
        }
    }
}
