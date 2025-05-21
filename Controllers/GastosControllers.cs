using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public GastosController(BarberiaConexion db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM gastos");
            var lista = dt.ToDictionaryList();  
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM gastos WHERE id_gasto = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Create(Gasto g)
        {
            var sql = @"INSERT INTO gastos 
                        (monto, descripcion, comprobante)
                        VALUES (@m,@d,@c)";
            var parms = new[]
            {
                new MySqlParameter("@m", g.Monto ?? (object)DBNull.Value),
                new MySqlParameter("@d", g.Descripcion ?? (object)DBNull.Value),
                new MySqlParameter("@c", g.Comprobante ?? (object)DBNull.Value)
            };
            _db.EjecutarComando(sql, parms);
            return CreatedAtAction(nameof(Get), new { id = g.IdGasto }, g);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Gasto g)
        {
            var sql = @"UPDATE gastos SET 
                        monto=@m, descripcion=@d, comprobante=@c
                        WHERE id_gasto=@id";
            var parms = new[]
            {
                new MySqlParameter("@m", g.Monto ?? (object)DBNull.Value),
                new MySqlParameter("@d", g.Descripcion ?? (object)DBNull.Value),
                new MySqlParameter("@c", g.Comprobante ?? (object)DBNull.Value),
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
                "DELETE FROM gastos WHERE id_gasto=@id",
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
*/