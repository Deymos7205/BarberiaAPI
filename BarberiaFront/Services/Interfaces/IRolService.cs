using BarberiaFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> ObtenerTodos();
        Task<Rol> ObtenerPorId(int id);
        Task Crear(Rol entidad);
        Task Actualizar(Rol entidad);
        Task Eliminar(int id);
    }
}
