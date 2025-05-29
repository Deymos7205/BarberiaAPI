using BarberiaFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Interfaces
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> ObtenerTodos();
        Task<Gasto> ObtenerPorId(int id);
        Task Crear(Gasto entidad);
        Task Actualizar(Gasto entidad);
        Task Eliminar(int id);
    }
}
