using BarberiaAPI.Model;
using BarberiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Pago>> Get() => Ok(BarberiaDataStore.Pagos);

        [HttpGet("{id}")]
        public ActionResult<Pago> Get(int id)
        {
            var p = BarberiaDataStore.Pagos.FirstOrDefault(x => x.Id == id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public ActionResult<Pago> Post(Pago pago)
        {
            pago.Id = BarberiaDataStore.Pagos.Max(x => x.Id) + 1;
            pago.FechaPago = DateTime.Now;
            BarberiaDataStore.Pagos.Add(pago);
            return CreatedAtAction(nameof(Get), new { id = pago.Id }, pago);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pago update)
        {
            var p = BarberiaDataStore.Pagos.FirstOrDefault(x => x.Id == id);
            if (p is null) return NotFound();
            p.Monto = update.Monto;
            p.MetodoPago = update.MetodoPago;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = BarberiaDataStore.Pagos.FirstOrDefault(x => x.Id == id);
            if (p is null) return NotFound();
            BarberiaDataStore.Pagos.Remove(p);
            return NoContent();
        }
    }
}
