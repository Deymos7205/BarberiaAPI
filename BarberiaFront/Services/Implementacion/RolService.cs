using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Implementacion
{
    public class RolService : IRolService
    {
        private readonly HttpClient _http;

        public RolService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Rol>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Rol>>("api/rol");

        public async Task<Rol> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Rol>($"api/rol/{id}");

        public async Task Crear(Rol entidad) =>
            await _http.PostAsJsonAsync("api/rol", entidad);

        public async Task Actualizar(Rol entidad) =>
            await _http.PutAsJsonAsync($"api/rol/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/rol/{id}");
    }
}
