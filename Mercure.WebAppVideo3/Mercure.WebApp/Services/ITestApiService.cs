using Mercure.Data.Cards;
using System.Text.Json;

namespace Mercure.WebApp.Services
{
    public interface ITestApiService
    {
        Task<List<Test>> GetTestAsync();
    }

    public class TestApiService : ITestApiService {

        private readonly HttpClient _httpClient;
        private readonly ILogger<TestApiService> _logger;
        public TestApiService(HttpClient httpClient, IConfiguration configuration, ILogger<TestApiService> logger) { 
        _httpClient = httpClient;
            _logger = logger;
            var baseUrl = configuration["ApiSettings:BaseUrl"];
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<List<Test>> GetTestAsync(){
            try
            {
                var response = await _httpClient.GetAsync("api/tests");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var tests = JsonSerializer.Deserialize<List<Test>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return tests ?? new List<Test>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur de data");
                return new List<Test>();
            }
        }
    
    }

}
