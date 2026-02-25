using PracticaMaui.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace PracticaMaui.Service
{
    public class EmployeeService : IRepositoryService<Employee>
    {
        
        // Añadir la ruta a la base dependiendo del endpoint que se quiera consumir
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
        private const string BaseUrl = "http://localhost:8085/employees";

        public async Task CreateAsync(Employee employee)
        {
            await _httpClient.PostAsJsonAsync(BaseUrl, employee, _serializeOptions);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{BaseUrl}/{employee.Id}")
            {
                Content = JsonContent.Create(employee, options: _serializeOptions)
            };
            await _httpClient.SendAsync(request);
        }

        public async Task DeleteAsync(int id)
        {
            using var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }


        public async Task<List<Employee>> GetAllAsync() => await _httpClient.GetFromJsonAsync<List<Employee>>(BaseUrl, _serializeOptions);


        public Task<Employee> GetById(int id) => _httpClient.GetFromJsonAsync<Employee>($"{BaseUrl}/{id}", _serializeOptions);
    }
}
