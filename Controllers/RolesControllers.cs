using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public RolesController(BarberiaConexion db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM roles");
            var lista = dt.ToDictionaryList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM roles WHERE id_rol = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Rol rol)
        {
            var sql = "INSERT INTO roles (nombre, descripcion) VALUES (@n,@d)";
            var p = new[]
            {
                new MySqlParameter("@n", rol.NombreRol),
                new MySqlParameter("@d", rol.Descripcion)
            };
            _db.EjecutarComando(sql, p);
            return CreatedAtAction(nameof(Get), new { id = rol.IdRol }, rol);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Rol rol)
        {
            var sql = "UPDATE roles SET nombre=@n, descripcion=@d WHERE id_rol=@id";
            var p = new[]
            {
                new MySqlParameter("@n", rol.NombreRol),
                new MySqlParameter("@d", rol.Descripcion),
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
                "DELETE FROM roles WHERE id_rol=@id",
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
*/