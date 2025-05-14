using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Horario>> Get() => Ok(BarberiaDataStore.Horarios);

        [HttpGet("{id}")]
        public ActionResult<Horario> Get(int id)
        {
            var h = BarberiaDataStore.Horarios.FirstOrDefault(x => x.Id == id);
            return h is null ? NotFound() : Ok(h);
        }

        [HttpPost]
        public ActionResult<Horario> Post(Horario horario)
        {
            horario.Id = BarberiaDataStore.Horarios.Max(x => x.Id) + 1;
            BarberiaDataStore.Horarios.Add(horario);
            return CreatedAtAction(nameof(Get), new { id = horario.Id }, horario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Horario update)
        {
            var h = BarberiaDataStore.Horarios.FirstOrDefault(x => x.Id == id);
            if (h is null) return NotFound();
            h.UsuarioId = update.UsuarioId;
            h.DiaSemana = update.DiaSemana;
            h.HoraInicio = update.HoraInicio;
            h.HoraFin = update.HoraFin;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var h = BarberiaDataStore.Horarios.FirstOrDefault(x => x.Id == id);
            if (h is null) return NotFound();
            BarberiaDataStore.Horarios.Remove(h);
            return NoContent();
        }
    }
}
