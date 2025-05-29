using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Implementacion
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _http;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Cliente>>("api/cliente");

        public async Task<Cliente> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Cliente>($"api/cliente/{id}");

        public async Task Crear(Cliente entidad) =>
            await _http.PostAsJsonAsync("api/cliente", entidad);

        public async Task Actualizar(Cliente entidad) =>
            await _http.PutAsJsonAsync($"api/cliente/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/cliente/{id}");
    }
}
