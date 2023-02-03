using FluentValidation.Results;
using MediatR;
using OEleitor.Infra.CrossCurtting.Validation;

namespace OEleitor.Infra.CrossCurtting.Messages
{
    public abstract class Command : Message, IRequest<ValidationResultBag>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command() => Timestamp = DateTime.Now;

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
