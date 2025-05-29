using BarberiaFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObtenerTodos();
        Task<Cliente> ObtenerPorId(int id);
        Task Crear(Cliente entidad);
        Task Actualizar(Cliente entidad);
        Task Eliminar(int id);
    }
}
