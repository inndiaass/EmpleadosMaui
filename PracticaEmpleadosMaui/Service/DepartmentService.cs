using PracticaMaui.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace PracticaMaui.Service
{
    public class DepartmentService : IRepositoryService<Department>
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
        private const string BaseUrl = "http://localhost:8085/departments";


        public async Task<List<Department>> GetAllAsync() => await _httpClient.GetFromJsonAsync<List<Department>>(BaseUrl, _serializeOptions);
           
        


        public Task<Department> GetById(int id) => _httpClient.GetFromJsonAsync<Department>($"{BaseUrl}/{id}", _serializeOptions);

        public async Task CreateAsync(Department department)
        {
            await _httpClient.PostAsJsonAsync(BaseUrl, department, _serializeOptions);
        }

        public async Task DeleteAsync(int id)
        {
            using var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Department department)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{BaseUrl}/{department.Id}")
            {
                Content = JsonContent.Create(department, options: _serializeOptions)
            };
            await _httpClient.SendAsync(request);
        }
    }
}
