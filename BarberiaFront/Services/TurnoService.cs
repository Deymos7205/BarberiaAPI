using BarberiaFront.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaFront.Services
{
    public class TurnoService
    {
        private readonly HttpClient _httpClient;

        public TurnoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los turnos
        public async Task<List<Turno>> GetTurnos()
        {
            return await _httpClient.GetFromJsonAsync<List<Turno>>("api/Turnos");
        }

        // Obtener un turno por ID
        public async Task<Turno> GetTurno(int id)
        {
            return await _httpClient.GetFromJsonAsync<Turno>($"api/Turnos/{id}");
        }

        // Crear un nuevo turno
        public async Task AddTurno(Turno turno)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Turnos", turno);
            response.EnsureSuccessStatusCode(); // Lanza una excepción si el código de estado no es de éxito (2xx)
        }

        // Actualizar un turno existente
        public async Task UpdateTurno(int id, Turno turno)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Turnos/{id}", turno);
            response.EnsureSuccessStatusCode();
        }

        // Eliminar un turno
        public async Task DeleteTurno(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Turnos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}