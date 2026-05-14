using DIseñoMongoDBExamen.Models;
using System.Net.Http.Json;

namespace DIseñoMongoDBExamen.Services
{
    public class DataService
    {
        private readonly HttpClient _http;

        private const string BaseUrl = "https://localhost:7139/api/";

        public DataService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            try
            {
                var response = await _http.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                    return new List<T>();

                var data = await response.Content.ReadFromJsonAsync<List<T>>();

                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GET ERROR:\n{ex.Message}");
                return new List<T>();
            }
        }

        public async Task<T?> GetByIdAsync<T>(string endpoint, Guid id)
        {
            try
            {
                var response = await _http.GetAsync($"{endpoint}/{id}");

                if (!response.IsSuccessStatusCode)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GET BY ID ERROR:\n{ex.Message}");
                return default;
            }
        }

        public async Task<bool> CreateAsync<T>(string endpoint, T data)
        {
            try
            {
                var res = await _http.PostAsJsonAsync(endpoint, data);

                if (!res.IsSuccessStatusCode)
                {
                    string error = await res.Content.ReadAsStringAsync();

                    MessageBox.Show($"POST ERROR:\n{error}");

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"POST EXCEPTION:\n{ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync<T>(string endpoint, Guid id, T data)
        {
            try
            {
                var res = await _http.PutAsJsonAsync($"{endpoint}/{id}", data);

                if (!res.IsSuccessStatusCode)
                {
                    string error = await res.Content.ReadAsStringAsync();

                    MessageBox.Show($"PUT ERROR:\n{error}");

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PUT EXCEPTION:\n{ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string endpoint, Guid id)
        {
            try
            {
                var res = await _http.DeleteAsync($"{endpoint}/{id}");

                if (!res.IsSuccessStatusCode)
                {
                    string error = await res.Content.ReadAsStringAsync();

                    MessageBox.Show($"DELETE ERROR:\n{error}");

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DELETE EXCEPTION:\n{ex.Message}");
                return false;
            }
        }

        public async Task<decimal> GetTotalIngresosAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<decimal>("Compra/total-ingresos");
            }
            catch
            {
                return 0;
            }
        }

        public async Task<decimal> GetTotalIvaAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<decimal>("Compra/total-iva");
            }
            catch
            {
                return 0;
            }
        }

        public async Task<Dictionary<string, decimal>> GetVentasPorCategoriaAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<Dictionary<string, decimal>>("Compra/ventas-por-categoria")
                    ?? new Dictionary<string, decimal>();
            }
            catch
            {
                return new Dictionary<string, decimal>();
            }
        }

        public async Task<Usuario?> LoginAsync(string username, string password)
        {
            try
            {
                var loginObj = new
                {
                    NombreUsuario = username,
                    Password = password
                };

                var res = await _http.PostAsJsonAsync("Usuario/login", loginObj);

                if (!res.IsSuccessStatusCode)
                    return null;

                var usuario = await res.Content.ReadFromJsonAsync<Usuario>();

                if (usuario != null)
                {
                    AuthService.UsuarioActual = usuario;

                    GlobalConfig.SucursalSeleccionadaId = usuario.SucursalId;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LOGIN ERROR:\n{ex.Message}");
                return null;
            }
        }
    }
}