using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public UsuariosController(BarberiaConexion db) => _db = db;


        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM usuarios");
            var lista = dt.ToDictionaryList();
            return Ok(lista);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM usuarios WHERE id_usuario = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Create(Usuario u)
        {
            var sql = @"
                INSERT INTO usuarios 
                  (nombre, cedula, telefono, contrasena, id_rol)
                VALUES
                  (@n, @c, @t, @p, @r)";
            var p = new[]
            {
                new MySqlParameter("@n", u.Nombre),
                new MySqlParameter("@c", u.Cedula),
                new MySqlParameter("@t", u.Telefono ?? (object)DBNull.Value),
                new MySqlParameter("@p", u.Contrasena),
                new MySqlParameter("@r", u.Id_Rol)
            };
            _db.EjecutarComando(sql, p);

            
            return CreatedAtAction(nameof(Get), new { id = u.Id_Usuario }, u);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario u)
        { 
            var sql = @"
                UPDATE usuarios SET
                  nombre     = @n,
                  cedula     = @c,
                  telefono   = @t,
                  contrasena = @p,
                  id_rol     = @r
                WHERE id_usuario = @id";
            var p = new[]
            {
                new MySqlParameter("@n", u.Nombre),
                new MySqlParameter("@c", u.Cedula),
                new MySqlParameter("@t", u.Telefono ?? (object)DBNull.Value),
                new MySqlParameter("@p", u.Contrasena),
                new MySqlParameter("@r", u.Id_Rol),
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
                "DELETE FROM usuarios WHERE id_usuario = @id",
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
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get() => Ok(BarberiaDataStore.Usuarios);

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var u = BarberiaDataStore.Usuarios.FirstOrDefault(x => x.Id == id);
            return u is null ? NotFound() : Ok(u);
        }

        [HttpPost]
        public ActionResult<Usuario> Post(Usuario usuario)
        {
            usuario.Id = BarberiaDataStore.Usuarios.Max(x => x.Id) + 1;
            BarberiaDataStore.Usuarios.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario update)
        {
            var u = BarberiaDataStore.Usuarios.FirstOrDefault(x => x.Id == id);
            if (u is null) return NotFound();
            u.NombreUsuario = update.NombreUsuario;
            u.Contrasena = update.Contrasena;
            u.RolId = update.RolId;
            u.Nombre = update.Nombre;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var u = BarberiaDataStore.Usuarios.FirstOrDefault(x => x.Id == id);
            if (u is null) return NotFound();
            BarberiaDataStore.Usuarios.Remove(u);
            return NoContent();
        }
    }
}
*/