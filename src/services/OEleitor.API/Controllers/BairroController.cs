using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OEleitor.API.Controllers;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Domain.Interfaces.Services;
using OEleitor.Domain.Mediator.Interfaces;

namespace Backoffice.Api.Controllers;

[Route("api/bairros")]
//[Authorize]
public class BairroController : MainController
{
    private readonly IBairroService _service;
    private readonly IBairroRepository _bairroRepository;
    private readonly IMediatorHandler _mediator;
    private readonly IMapper _mapper;


    public BairroController(IMediatorHandler mediator, IBairroService service, IBairroRepository bairroRepository, IMapper mapper)
    {
        _service = service;
        _bairroRepository = bairroRepository;
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
    public async Task<PagedResult<Bairro>> GetByAll([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
    {
        var bairros = await _bairroRepository.ObterTodos(ps,page,q);
        return bairros;
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
