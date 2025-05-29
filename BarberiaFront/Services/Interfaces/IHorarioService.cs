using BarberiaFront.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Interfaces
{
    public interface IHorarioService
    {
        Task<IEnumerable<Horario>> ObtenerTodos();
        Task<Horario> ObtenerPorId(int id);
        Task Crear(Horario entidad);
        Task Actualizar(Horario entidad);
        Task Eliminar(int id);
    }
}

