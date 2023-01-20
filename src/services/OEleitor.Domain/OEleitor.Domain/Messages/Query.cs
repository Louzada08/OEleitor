using FluentValidation.Results;
using MediatR;
using OEleitor.Domain.Validation;

namespace OEleitor.Domain.Messages
{
    public abstract class Query : IRequest<ValidationResultBag>
    {
        public ValidationResult ValidationResult { get; } = new ValidationResultBag();

        public abstract bool IsValid();
    }
}
