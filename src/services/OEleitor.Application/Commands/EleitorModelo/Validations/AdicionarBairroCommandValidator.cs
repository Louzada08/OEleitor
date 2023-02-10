using FluentValidation;
using OEleitor.Application.Commands.EleitorModelo.Requests;

namespace OEleitor.Application.Commands.EleitorModelo.Validations
{
    public class AdicionarBairroValidation : AbstractValidator<AdicionarBairroCommand>
    {
        public AdicionarBairroValidation()
        {
            RuleFor(x => x.BairroNome)
                .NotEmpty().WithMessage("O Nome deve ser informado.");
        }
    }
}
