using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OEleitor.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAlteracao { get; protected set; }
        public DateTime DataExclusao { get; protected set; }

        protected Entity()
        {
            ValidationResult = new ValidationResult();

            DataCadastro = BrazilianDateTime();
            DataAlteracao = BrazilianDateTime();
            DataExclusao = BrazilianDateTime();
        }

        public DateTime BrazilianDateTime()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo horaBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, horaBrasilia);
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void AddDomainNotification(string property, string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(property, message));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            return item.Id == this.Id;
        }

        public void Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            validator.Validate(model).Errors.ToList().ForEach(error => { ValidationResult.Errors.Add(error); });
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();

        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

    }
}
