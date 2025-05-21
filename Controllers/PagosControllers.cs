using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public PagosController(BarberiaConexion db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM pagos");
            var lista = dt.ToDictionaryList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM pagos WHERE id_pago = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Pago p)
        {
            var sql = @"INSERT INTO pagos 
                        (id_turno, monto, metodo_pago)
                        VALUES (@t,@m,@mp)";
            var parms = new[]
            {
                new MySqlParameter("@t", p.IdTurno),
                new MySqlParameter("@m", p.Monto   ?? (object)DBNull.Value),
                new MySqlParameter("@mp", p.MetodoPago ?? (object)DBNull.Value)
            };
            _db.EjecutarComando(sql, parms);
            return CreatedAtAction(nameof(Get), new { id = p.IdPago }, p);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pago p)
        {
            var sql = @"UPDATE pagos SET 
                        id_turno=@t, monto=@m, metodo_pago=@mp
                        WHERE id_pago=@id";
            var parms = new[]
            {
                new MySqlParameter("@t", p.IdTurno),
                new MySqlParameter("@m", p.Monto   ?? (object)DBNull.Value),
                new MySqlParameter("@mp", p.MetodoPago ?? (object)DBNull.Value),
                new MySqlParameter("@id", id)
            };
            var filas = _db.EjecutarComando(sql, parms);
            if (filas == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filas = _db.EjecutarComando(
                "DELETE FROM pagos WHERE id_pago=@id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (filas == 0) return NotFound();
            return NoContent();
        }
    }
}


/*
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
*/