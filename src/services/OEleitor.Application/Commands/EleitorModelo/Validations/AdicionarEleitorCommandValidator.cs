using FluentValidation;
using OEleitor.Application.Commands.EleitorModelo.Requests;

namespace OEleitor.Application.Commands.EleitorModelo.Validations
{
    public class AdicionarEleitorCommandValidator : AbstractValidator<AdicionarEleitorCommand>
    {
        public AdicionarEleitorCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome deve ser informado.");
        }
    }
}
