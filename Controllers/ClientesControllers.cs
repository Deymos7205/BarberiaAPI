using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using BarberiaAPI.Services;
using BarberiaAPI.Model;

namespace BarberiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly BarberiaConexion _db;
        public ClientesController(BarberiaConexion db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _db.EjecutarConsulta("SELECT * FROM clientes");
            var lista = dt.ToDictionaryList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM clientes WHERE id_cliente = @id",
                new[] { new MySqlParameter("@id", id) }
            );
            if (dt.Rows.Count == 0)
                return NotFound();

            var item = dt.ToDictionaryList().First();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Cliente cli)
        {
            var sql = @"INSERT INTO clientes 
                        (nombre, cedula, telefono, direccion, preferencias)
                        VALUES (@n,@c,@t,@d,@p)";
            var p = new[]
            {
                new MySqlParameter("@n", cli.Nombre),
                new MySqlParameter("@c", cli.Cedula),
                new MySqlParameter("@t", cli.Telefono ?? (object)DBNull.Value),
                new MySqlParameter("@d", cli.Direccion ?? (object)DBNull.Value),
                new MySqlParameter("@p", cli.Preferencias ?? (object)DBNull.Value),
            };
            var filas = _db.EjecutarComando(sql, p);
            return CreatedAtAction(nameof(Get), new { id = cli.IdCliente }, new { filas });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Cliente cli)
        {
            var sql = @"UPDATE clientes SET 
                        nombre=@n, cedula=@c, telefono=@t, 
                        direccion=@d, preferencias=@p
                        WHERE id_cliente=@id";
            var p = new[]
            {
                new MySqlParameter("@n", cli.Nombre),
                new MySqlParameter("@c", cli.Cedula),
                new MySqlParameter("@t", cli.Telefono ?? (object)DBNull.Value),
                new MySqlParameter("@d", cli.Direccion ?? (object)DBNull.Value),
                new MySqlParameter("@p", cli.Preferencias ?? (object)DBNull.Value),
                new MySqlParameter("@id", id),
            };
            var filas = _db.EjecutarComando(sql, p);
            if (filas == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filas = _db.EjecutarComando(
                "DELETE FROM clientes WHERE id_cliente=@id",
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
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get() => Ok(BarberiaDataStore.Clientes);

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var c = BarberiaDataStore.Clientes.FirstOrDefault(x => x.Id == id);
            return c is null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            cliente.Id = BarberiaDataStore.Clientes.Max(x => x.Id) + 1;
            cliente.FechaRegistro = DateTime.Now;
            BarberiaDataStore.Clientes.Add(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente update)
        {
            var c = BarberiaDataStore.Clientes.FirstOrDefault(x => x.Id == id);
            if (c is null) return NotFound();
            c.Nombre = update.Nombre;
            c.Cedula = update.Cedula;
            c.Telefono = update.Telefono;
            c.Direccion = update.Direccion;
            c.Preferencias = update.Preferencias;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = BarberiaDataStore.Clientes.FirstOrDefault(x => x.Id == id);
            if (c is null) return NotFound();
            BarberiaDataStore.Clientes.Remove(c);
            return NoContent();
        }
    }
}
*/