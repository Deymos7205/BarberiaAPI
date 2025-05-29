using BarberiaFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Interfaces
{
    public interface ITurnoService
    {
        Task<IEnumerable<Turno>> ObtenerTodos();
        Task<Turno> ObtenerPorId(int id);
        Task Crear(Turno entidad);
        Task Actualizar(Turno entidad);
        Task Eliminar(int id);
    }
}
