using AutoMapper;
using Microsoft.Extensions.Options;
using OEleitor.WebApp.MVC.Dtos;
using OEleitor.WebApp.MVC.Extensions;
using OEleitor.WebApp.MVC.Filtros;
using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Services
{
    public class EleitorService : Service, IEleitorService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public EleitorService(HttpClient httpClient, IOptions<AppSettings> settings, IMapper mapper)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.EleitorUrl);
            _mapper = mapper;
        }

        public async Task<PagedViewModel<EleitorViewModel>> ObterTodosEleitores(int pageSize, int pageIndex, string query = null)
        {
            var response = await _httpClient.GetAsync($"api/eleitores/obtertodos?ps={pageSize}&page={pageIndex}&q={query}");

            TratarErrosResponse(response);

            var eleitoresResponse = await DeserializarObjetoResponse<PagedViewModel<EleitorViewModel>>(response);

            return eleitoresResponse;
        }

        public async Task<EleitorViewModel> ObterPorId(Guid? EleitorId)
        {
            var response = await _httpClient.GetAsync($"api/eleitores/{EleitorId}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<EleitorViewModel>(response);
        }

        public async Task<ResponseResult> AdicionarEleitor(EleitorViewModel eleitor)
        {
            var eleitorDTO = _mapper.Map<EleitorDTO>(eleitor);

            var eleitorContent = ObterConteudo(eleitorDTO);

            var response = await _httpClient.PostAsync("/api/eleitores", eleitorContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }
    }
}