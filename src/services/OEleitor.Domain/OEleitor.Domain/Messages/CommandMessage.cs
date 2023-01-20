using System;
using FluentValidation.Results;
using MediatR;
using OEleitor.Domain.Validation;

namespace OEleitor.Domain.Messages
{
    public abstract class CommandMessage : Message, IRequest<ValidationResultBag>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected CommandMessage() => Timestamp = DateTime.Now;

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
