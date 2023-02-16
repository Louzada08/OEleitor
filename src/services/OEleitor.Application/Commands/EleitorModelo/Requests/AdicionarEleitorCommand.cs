using OEleitor.Application.Commands.EleitorModelo.Validations;
using OEleitor.Domain.Entities;
using OEleitor.Infra.CrossCurtting.Messages;
using System;
using System.Collections.Generic;

namespace OEleitor.Application.Commands.EleitorModelo.Requests;

public class AdicionarEleitorCommand : Command
{
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public DateTime? Aniversario { get; set; }
    public SexoEleitor Sexo { get; set; }
    public string? Email { get; set; }
    public FoneEleitor Fone { get; set; }
    public string? Observacao { get; set; }
    public Endereco Endereco { get; set; }
    public IEnumerable<AdicionarDependenteCommand> Dependentes { get; set; }

    public override bool IsValid()
    {
        ValidationResult = new AdicionarEleitorValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
