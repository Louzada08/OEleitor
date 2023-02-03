using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OEleitor.API.Controllers;

[ApiController]
public abstract class MainController : Controller
{
    protected ICollection<string> Erros = new List<string>();

    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
            return Ok(result);

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            {"Mensagens", Erros.ToArray() }
        }));
    }

    protected ActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach (var erro in validationResult.Errors)
        {
            AdicionarErroProcessamento(erro.ErrorMessage);
        }

        return CustomResponse();
    }

    protected bool OperacaoValida()
    {
        return !Erros.Any();
    }

    protected void AdicionarErroProcessamento(string erro)
    {
        Erros.Add(erro);
    }

    protected void LimparErrosProcessamento()
    {
        Erros.Clear();
    }
}