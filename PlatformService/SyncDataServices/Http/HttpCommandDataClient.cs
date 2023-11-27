using System.Text;
using System.Text.Json;
using PlatformService.DTOs;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDTO platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "applicant/json");
            
            var commandServiceUrl = _configuration.GetValue<string>("CommandServiceUrl");
            var url = $"{commandServiceUrl}/platformservice";
            var response = await _httpClient.PostAsync(url, httpContent);
            
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("---> Successfully connected to Command Service Application. :)");
            }
            else
            {
                Console.WriteLine("---> Failed to connec Command Service Application. :(");
            }
        }
    }
}