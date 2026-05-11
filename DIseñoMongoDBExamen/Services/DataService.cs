using DIseñoMongoDBExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DIseñoMongoDBExamen.Services
{
    public class DataService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "https://localhost:7139/api/";

        public DataService()
        {
            _http = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        // --- MÉTODOS GENÉRICOS (Sirven para todos los CRUDs) ---
        public async Task<List<T>> GetAllAsync<T>(string endpoint)
            => await _http.GetFromJsonAsync<List<T>>(endpoint);

        public async Task<bool> CreateAsync<T>(string endpoint, T data)
        {
            var res = await _http.PostAsJsonAsync(endpoint, data);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync<T>(string endpoint, Guid id, T data)
        {
            var res = await _http.PutAsJsonAsync($"{endpoint}/{id}", data);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string endpoint, Guid id)
        {
            var res = await _http.DeleteAsync($"{endpoint}/{id}");
            return res.IsSuccessStatusCode;
        }

        // --- MÉTODOS ESPECIALES DE ANALÍTICA ---
        public async Task<decimal> GetTotalIngresosAsync()
            => await _http.GetFromJsonAsync<decimal>("Compra/total-ingresos");

        public async Task<decimal> GetTotalIvaAsync()
            => await _http.GetFromJsonAsync<decimal>("Compra/total-iva");

        public async Task<Dictionary<string, decimal>> GetVentasPorCategoriaAsync()
            => await _http.GetFromJsonAsync<Dictionary<string, decimal>>("Compra/ventas-por-categoria");

        // --- LOGIN ---
        public async Task<Usuario> LoginAsync(string username, string password)
        {
            var loginObj = new { NombreUsuario = username, Password = password };
            var res = await _http.PostAsJsonAsync("Usuario/login", loginObj);

            if (res.IsSuccessStatusCode)
            {
                var usuario = await res.Content.ReadFromJsonAsync<Usuario>();
                AuthService.UsuarioActual = usuario;
                return usuario;
            }
            return null;
        }
    }
}
