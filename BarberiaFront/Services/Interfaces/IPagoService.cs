using BarberiaFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Interfaces
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> ObtenerTodos();
        Task<Pago> ObtenerPorId(int id);
        Task Crear(Pago entidad);
        Task Actualizar(Pago entidad);
        Task Eliminar(int id);
    }
}
