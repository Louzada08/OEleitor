using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
