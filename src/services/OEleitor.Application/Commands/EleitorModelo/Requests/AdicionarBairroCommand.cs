using OEleitor.Application.Commands.EleitorModelo.Validations;
using OEleitor.Infra.CrossCurtting.Messages;

namespace OEleitor.Application.Commands.EleitorModelo.Requests;

public class AdicionarBairroCommand : Command
{
    public string BairroNome { get; set; }
    public override bool IsValid()
    {
        ValidationResult = new AdicionarBairroValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
