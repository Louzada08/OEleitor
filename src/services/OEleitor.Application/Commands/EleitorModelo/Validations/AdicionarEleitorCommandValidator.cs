using FluentValidation;
using OEleitor.Application.Commands.EleitorModelo.Requests;

namespace OEleitor.Application.Commands.EleitorModelo.Validations
{
    public class AdicionarEleitorValidation : AbstractValidator<AdicionarEleitorCommand>
    {
        public AdicionarEleitorValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome deve ser informado.");
        }
    }
}
