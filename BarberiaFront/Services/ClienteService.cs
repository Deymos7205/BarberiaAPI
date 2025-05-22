using BarberiaFront.Models; 
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BarberiaFront.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        
        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obtener todos los clientes
        public async Task<List<Cliente>> GetClientes()
        {
            return await _httpClient.GetFromJsonAsync<List<Cliente>>("api/Clientes");
        }

        // Método para obtener un cliente por ID
        public async Task<Cliente> GetCliente(int id)
        {
            return await _httpClient.GetFromJsonAsync<Cliente>($"api/Clientes/{id}");
        }

        // Método para agregar un nuevo cliente
        public async Task AddCliente(Cliente cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Clientes", cliente);
            response.EnsureSuccessStatusCode(); // Lanza una excepción si el código de estado no es de éxito (2xx)
        }

        // Método para actualizar un cliente existente
        public async Task UpdateCliente(int id, Cliente cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Clientes/{id}", cliente);
            response.EnsureSuccessStatusCode();
        }

        // Método para eliminar un cliente
        public async Task DeleteCliente(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Clientes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}