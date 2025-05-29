using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Implementacion
{
    public class HorarioService : IHorarioService
    {
        private readonly HttpClient _http;

        public HorarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Horario>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Horario>>("api/horario");

        public async Task<Horario> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Horario>($"api/horario/{id}");

        public async Task Crear(Horario entidad) =>
            await _http.PostAsJsonAsync("api/horario", entidad);

        public async Task Actualizar(Horario entidad) =>
            await _http.PutAsJsonAsync($"api/horario/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/horario/{id}");
    }
}
