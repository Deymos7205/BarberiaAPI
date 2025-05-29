using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services
{
    public class GastoService : IGastoService
    {
        private readonly HttpClient _http;

        public GastoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Gasto>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Gasto>>("api/gasto");

        public async Task<Gasto> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Gasto>($"api/gasto/{id}");

        public async Task Crear(Gasto entidad) =>
            await _http.PostAsJsonAsync("api/gasto", entidad);

        public async Task Actualizar(Gasto entidad) =>
            await _http.PutAsJsonAsync($"api/gasto/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/gasto/{id}");
    }
}
