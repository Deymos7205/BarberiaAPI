using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Gasto>> Get() => Ok(BarberiaDataStore.Gastos);

        [HttpGet("{id}")]
        public ActionResult<Gasto> Get(int id)
        {
            var g = BarberiaDataStore.Gastos.FirstOrDefault(x => x.Id == id);
            return g is null ? NotFound() : Ok(g);
        }

        [HttpPost]
        public ActionResult<Gasto> Post(Gasto gasto)
        {
            gasto.Id = BarberiaDataStore.Gastos.Max(x => x.Id) + 1;
            BarberiaDataStore.Gastos.Add(gasto);
            return CreatedAtAction(nameof(Get), new { id = gasto.Id }, gasto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Gasto update)
        {
            var g = BarberiaDataStore.Gastos.FirstOrDefault(x => x.Id == id);
            if (g is null) return NotFound();
            g.Monto = update.Monto;
            g.Descripcion = update.Descripcion;
            g.Comprobante = update.Comprobante;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var g = BarberiaDataStore.Gastos.FirstOrDefault(x => x.Id == id);
            if (g is null) return NotFound();
            BarberiaDataStore.Gastos.Remove(g);
            return NoContent();
        }
    }
}
