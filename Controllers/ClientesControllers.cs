using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get() => Ok(BarberiaDataStore.Clientes);

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var c = BarberiaDataStore.Clientes.FirstOrDefault(x => x.Id == id);
            return c is null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            cliente.Id = BarberiaDataStore.Clientes.Max(x => x.Id) + 1;
            cliente.FechaRegistro = DateTime.Now;
            BarberiaDataStore.Clientes.Add(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente update)
        {
            var c = BarberiaDataStore.Clientes.FirstOrDefault(x => x.Id == id);
            if (c is null) return NotFound();
            c.Nombre = update.Nombre;
            c.Cedula = update.Cedula;
            c.Telefono = update.Telefono;
            c.Direccion = update.Direccion;
            c.Preferencias = update.Preferencias;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = BarberiaDataStore.Clientes.FirstOrDefault(x => x.Id == id);
            if (c is null) return NotFound();
            BarberiaDataStore.Clientes.Remove(c);
            return NoContent();
        }
    }
}

