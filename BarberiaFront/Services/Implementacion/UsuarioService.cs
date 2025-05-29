using BarberiaFront.Models;
using BarberiaFront.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos() =>
            await _http.GetFromJsonAsync<IEnumerable<Usuario>>("api/usuario");

        public async Task<Usuario> ObtenerPorId(int id) =>
            await _http.GetFromJsonAsync<Usuario>($"api/usuario/{id}");

        public async Task Crear(Usuario entidad) =>
            await _http.PostAsJsonAsync("api/usuario", entidad);

        public async Task Actualizar(Usuario entidad) =>
            await _http.PutAsJsonAsync($"api/usuario/{entidad.Id}", entidad);

        public async Task Eliminar(int id) =>
            await _http.DeleteAsync($"api/usuario/{id}");
    }
}
