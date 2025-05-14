using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Rol>> Get() => Ok(BarberiaDataStore.Roles);

        [HttpGet("{id}")]
        public ActionResult<Rol> Get(int id)
        {
            var r = BarberiaDataStore.Roles.FirstOrDefault(x => x.Id == id);
            return r is null ? NotFound() : Ok(r);
        }

        [HttpPost]
        public ActionResult<Rol> Post(Rol rol)
        {
            rol.Id = BarberiaDataStore.Roles.Max(x => x.Id) + 1;
            BarberiaDataStore.Roles.Add(rol);
            return CreatedAtAction(nameof(Get), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rol update)
        {
            var r = BarberiaDataStore.Roles.FirstOrDefault(x => x.Id == id);
            if (r is null) return NotFound();
            r.NombreRol = update.NombreRol;
            r.Descripcion = update.Descripcion;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var r = BarberiaDataStore.Roles.FirstOrDefault(x => x.Id == id);
            if (r is null) return NotFound();
            BarberiaDataStore.Roles.Remove(r);
            return NoContent();
        }
    }
}
