using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Turno>> Get() => Ok(BarberiaDataStore.Turnos);

        [HttpGet("{id}")]
        public ActionResult<Turno> Get(int id)
        {
            var t = BarberiaDataStore.Turnos.FirstOrDefault(x => x.Id == id);
            return t is null ? NotFound() : Ok(t);
        }

        [HttpPost]
        public ActionResult<Turno> Post(Turno turno)
        {
            turno.Id = BarberiaDataStore.Turnos.Max(x => x.Id) + 1;
            BarberiaDataStore.Turnos.Add(turno);
            return CreatedAtAction(nameof(Get), new { id = turno.Id }, turno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Turno update)
        {
            var t = BarberiaDataStore.Turnos.FirstOrDefault(x => x.Id == id);
            if (t is null) return NotFound();
            t.ClienteId = update.ClienteId;
            t.UsuarioId = update.UsuarioId;
            t.Fecha = update.Fecha;
            t.Hora = update.Hora;
            t.TipoCorte = update.TipoCorte;
            t.Precio = update.Precio;
            t.Notas = update.Notas;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var t = BarberiaDataStore.Turnos.FirstOrDefault(x => x.Id == id);
            if (t is null) return NotFound();
            BarberiaDataStore.Turnos.Remove(t);
            return NoContent();
        }
    }
}
