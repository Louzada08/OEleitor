using Microsoft.Extensions.Options;
using OEleitor.WebApp.MVC.Extensions;
using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public class BairroService : Service, IBairroService
    {
        private readonly HttpClient _httpClient;

        public BairroService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.BairroUrl);
        }

        public async Task<IEnumerable<BairroViewModel>> ObterTodosBairros()
        {
            var response = await _httpClient.GetAsync("api/bairros");

            TratarErrosResponse(response);

            var bairro = await DeserializarObjetoResponse<IEnumerable<BairroViewModel>>(response);
            return bairro;
        }
    }
}