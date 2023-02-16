using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OEleitor.API.Controllers;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Application.Query.Interface;
using OEleitor.Domain.Filtros;
using OEleitor.Domain.Interfaces.Services;
using OEleitor.Domain.Mediator.Interfaces;

namespace Backoffice.Api.Controllers;

[Route("api/bairros")]
//[Authorize]
public class BairroController : MainController
{
    private readonly IBairroService _service;
    private readonly IBairroQuery _bairroQuery;
    private readonly IMediatorHandler _mediator;
    private readonly IMapper _mapper;


    public BairroController(IMediatorHandler mediator, IBairroService service, IBairroQuery bairroQuery, IMapper mapper)
    {
        _service = service;
        _bairroQuery = bairroQuery;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AdicionarEleitorResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] AdicionarBairroCommand command)
    {
        var response = await _mediator.EnviarComando(command);
        return CustomResponse(response);
    }


    [HttpGet("obtertodos")]
    [ProducesResponseType(typeof(BairroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BairroResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByAll([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] BairroQueryFiltro q = null)
    {
        var bairros = await _bairroQuery.ObterPaginadoTodos(ps,page,q);
        return CustomResponse(bairros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BairroDetalhe(Guid? id)
    {
        if (id is null) return CustomResponse(NotFound());

        var bairro = await _service.ObterPorId(id);

        if (bairro is null) return CustomResponse("Nenhum Bairro foi encontrado.");

        return CustomResponse(bairro);
    }

}
