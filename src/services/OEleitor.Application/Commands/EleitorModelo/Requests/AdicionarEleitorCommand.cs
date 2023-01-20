using OEleitor.Application.Commands.EleitorModelo.Validations;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Messages;
using System;
using System.Collections.Generic;
using static OEleitor.Domain.Entities.Eleitor;

namespace OEleitor.Application.Commands.EleitorModelo.Requests;

public class AdicionarEleitorCommand : Command
{
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public DateTime? Aniversario { get; set; }
    public SexoEleitor Sexo { get; set; }
    public string? Email { get; set; }
    public Endereco Endereco { get; set; }
    public FoneEleitor Fone { get; set; }
    public ICollection<Dependente> Dependentes { get; set; }
    public string? Observacao { get; set; }

    public override bool IsValid()
    {
        ValidationResult = new AdicionarEleitorCommandValidator().Validate(this);
        return ValidationResult.IsValid;
    }
}
