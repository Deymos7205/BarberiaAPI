using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public HorariosController(BarberiaConexion db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM horarios");
            var lista = dt.ToDictionaryList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM horarios WHERE id_horario = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Horario h)
        {
            var sql = @"INSERT INTO horarios 
                        (id_usuario, dia_semana, hora_inicio, hora_fin)
                        VALUES (@u,@d,@hi,@hf)";
            var parms = new[]
            {
                new MySqlParameter("@u", h.IdUsuario),
                new MySqlParameter("@d", h.DiaSemana ?? (object)DBNull.Value),
                new MySqlParameter("@hi", h.HoraInicio ?? (object)DBNull.Value),
                new MySqlParameter("@hf", h.HoraFin    ?? (object)DBNull.Value)
            };
            _db.EjecutarComando(sql, parms);
            return CreatedAtAction(nameof(Get), new { id = h.IdHorario }, h);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Horario h)
        {
            var sql = @"UPDATE horarios SET 
                        id_usuario=@u, dia_semana=@d, 
                        hora_inicio=@hi, hora_fin=@hf
                        WHERE id_horario=@id";
            var parms = new[]
            {
                new MySqlParameter("@u", h.IdUsuario),
                new MySqlParameter("@d", h.DiaSemana ?? (object)DBNull.Value),
                new MySqlParameter("@hi", h.HoraInicio ?? (object)DBNull.Value),
                new MySqlParameter("@hf", h.HoraFin    ?? (object)DBNull.Value),
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
                "DELETE FROM horarios WHERE id_horario=@id",
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
*/