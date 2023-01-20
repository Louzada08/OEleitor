using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OEleitor.API.Controllers;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Domain.Interfaces.Services;
using OEleitor.Domain.Validation;

namespace Backoffice.Api.Controllers;

[Route("api/eleitores")]
//[Authorize]
public class EleitorController : MainController
{
    private readonly IEleitorService _service;

    public EleitorController(IMediator mediator, IEleitorService service, IMapper mapper) : base(mapper, mediator)
    {
        _service = service;
    } 

    [HttpPost]
   // [Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(AdicionarEleitorResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] AdicionarEleitorCommand command)
    {
        var response = await _mediator.Send(command);
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

            var bag = new ValidationResultBag();
            bag.Errors.Add(new ValidationFailure("error", "Customer not found.", StatusCodes.Status404NotFound));
            return CustomResponse(bag);
        }
        catch (Exception ex)
        {
            var bag = new ValidationResultBag();
            bag.Errors.Add(new ValidationFailure("error", ex.Message));
            return CustomResponse(bag);
        }
    }

}
