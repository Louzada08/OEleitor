using FluentValidation.Results;
using MediatR;

namespace OEleitor.Infra.CrossCurtting.Messages
{
    public abstract class Query : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; } = new ValidationResult();

        public abstract bool IsValid();
    }
}
