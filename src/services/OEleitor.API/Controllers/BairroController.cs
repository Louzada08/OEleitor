using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OEleitor.API.Controllers;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Domain.Interfaces.Services;
using OEleitor.Domain.Mediator.Interfaces;

namespace Backoffice.Api.Controllers;

[Route("api/bairros")]
//[Authorize]
public class BairroController : MainController
{
    private readonly IBairroService _service;
    private readonly IMediatorHandler _mediator;
    private readonly IMapper _mapper;


    public BairroController(IMediatorHandler mediator, IBairroService service, IMapper mapper) 
    {
        _service = service;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    // [Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(AdicionarEleitorResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] AdicionarEleitorCommand command)
    {
        var response = await _mediator.EnviarComando(command);
        return CustomResponse(response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(BairroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BairroResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByAll()
    {
        try
        {
            var bairros = _mapper.Map<IEnumerable<BairroResponse>>(await _service.ObterTodos());

            if (bairros is not null) return CustomResponse(bairros);

            return CustomResponse("Bairro not found.");
        }
        catch (Exception ex)
        {
            return CustomResponse(ex.Message);
        }
    }

}
