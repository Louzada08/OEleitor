using OEleitor.Domain.Entities;
using OEleitor.Infra.CrossCurtting.Messages;
using System;

namespace OEleitor.Application.Commands.EleitorModelo.Requests;

public class AdicionarDependenteCommand : Command
{
    public Guid EleitorId { get; set; }
    public string Nome { get; set; }
    public TipoDependente Tipo { get; set; }
    public DateTime? Nascimento { get; set; }
    public string? Fone { get; set; }

    //public override bool IsValid()
    //{
    //    ValidationResult = new AdicionarEleitorCommandValidator().Validate(this);
    //    return ValidationResult.IsValid;
    //}
}
