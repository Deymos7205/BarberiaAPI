using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Implementacion
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _http;

        public PagoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Pago>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Pago>>("api/pago");

        public async Task<Pago> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Pago>($"api/pago/{id}");

        public async Task Crear(Pago entidad) =>
            await _http.PostAsJsonAsync("api/pago", entidad);

        public async Task Actualizar(Pago entidad) =>
            await _http.PutAsJsonAsync($"api/pago/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/pago/{id}");
    }
}
