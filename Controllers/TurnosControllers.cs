using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public TurnosController(BarberiaConexion db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM turnos");
            var lista = dt.ToDictionaryList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM turnos WHERE id_turno = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Turno t)
        {
            var sql = @"INSERT INTO turnos 
                        (id_cliente, id_usuario, fecha, hora, tipo_corte, precio, notas)
                        VALUES (@c,@u,@f,@h,@tc,@pr,@nt)";
            var p = new[]
            {
                new MySqlParameter("@c", t.IdCliente),
                new MySqlParameter("@u", t.IdUsuario),
                new MySqlParameter("@f", t.Fecha),
                new MySqlParameter("@h", t.Hora),
                new MySqlParameter("@tc", t.TipoCorte ?? (object)DBNull.Value),
                new MySqlParameter("@pr",t.Precio.HasValue? (object)t.Precio.Value: DBNull.Value),
                new MySqlParameter("@nt", t.Notas   ?? (object)DBNull.Value)
            };
            _db.EjecutarComando(sql, p);
            return CreatedAtAction(nameof(Get), new { id = t.IdTurno }, t);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Turno t)
        {
            var sql = @"UPDATE turnos SET 
                        id_cliente=@c, id_usuario=@u, fecha=@f, hora=@h, 
                        tipo_corte=@tc, precio=@pr, notas=@nt
                        WHERE id_turno=@id";
            var p = new[]
            {
                new MySqlParameter("@c", t.IdCliente),
                new MySqlParameter("@u", t.IdUsuario),
                new MySqlParameter("@f", t.Fecha),
                new MySqlParameter("@h", t.Hora),
                new MySqlParameter("@tc", t.TipoCorte ?? (object)DBNull.Value),
                new MySqlParameter("@pr", t.Precio ?? (object)DBNull.Value),
                new MySqlParameter("@nt", t.Notas   ?? (object)DBNull.Value),
                new MySqlParameter("@id", id)
            };
            var filas = _db.EjecutarComando(sql, p);
            if (filas == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filas = _db.EjecutarComando(
                "DELETE FROM turnos WHERE id_turno=@id",
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
*/