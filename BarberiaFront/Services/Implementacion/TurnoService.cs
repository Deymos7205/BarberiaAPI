using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Implementations
{
    public class TurnoService : ITurnoService
    {
        private readonly HttpClient _http;

        public TurnoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Turno>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Turno>>("api/turno");

        public async Task<Turno> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Turno>($"api/turno/{id}");

        public async Task Crear(Turno entidad) =>
            await _http.PostAsJsonAsync("api/turno", entidad);

        public async Task Actualizar(Turno entidad) =>
            await _http.PutAsJsonAsync($"api/turno/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/turno/{id}");
    }
}
