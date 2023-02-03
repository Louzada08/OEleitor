using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OEleitor.API.Controllers;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Domain.Interfaces.Services;
using OEleitor.Domain.Mediator.Interfaces;

namespace Backoffice.Api.Controllers;

[Route("api/eleitores")]
//[Authorize]
public class EleitorController : MainController
{
    private readonly IEleitorService _service;
    private readonly IMediatorHandler _mediator;
    private readonly IMapper _mapper;


    public EleitorController(IMediatorHandler mediator, IEleitorService service, IMapper mapper) 
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


    [HttpGet("{ObterPorId:Guid}")]
    [ProducesResponseType(typeof(EleitorResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EleitorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerById(Guid ObterPorId)
    {
        try
        {
            var customer = _mapper.Map<EleitorResponse>(await _service.ObterPorId(ObterPorId));

            if (customer is not null) return CustomResponse(customer);

            return CustomResponse("Customer not found.");
        }
        catch (Exception ex)
        {
            return CustomResponse(ex.Message);
        }
    }

}
