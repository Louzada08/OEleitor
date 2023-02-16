using AutoMapper;
using Microsoft.Extensions.Options;
using OEleitor.WebApp.MVC.Dtos;
using OEleitor.WebApp.MVC.Extensions;
using OEleitor.WebApp.MVC.Filtros;
using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public class BairroService : Service, IBairroService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public BairroService(HttpClient httpClient, IOptions<AppSettings> settings, IMapper mapper)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.BairroUrl);
            _mapper = mapper;
        }

        public async Task<PagedViewModel<BairroViewModel>> ObterTodosBairros(int pageSize, int pageIndex, string query = null)
        {
            var response = await _httpClient.GetAsync($"api/bairros/obtertodos?ps={pageSize}&page={pageIndex}&q={query}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PagedViewModel<BairroViewModel>>(response);
        }

        public async Task<BairroViewModel> ObterPorId(Guid? bairroId)
        {
            var response = await _httpClient.GetAsync($"api/bairros/{bairroId}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<BairroViewModel>(response);
        }

        public async Task<ResponseResult> AdicionarBairro(BairroViewModel bairro)
        {
            var bairroDTO = _mapper.Map<BairroDTO>(bairro);

            var bairroContent = ObterConteudo(bairroDTO);

            var response = await _httpClient.PostAsync("/api/bairros", bairroContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }
    }
}