using OEleitor.Domain.Interfaces.Base;
using System;

namespace OEleitor.Domain.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public BaseEntity(DateTime dataCadastro) : this()
        {
            DataCadastro = dataCadastro;
        }
        public BaseEntity(Guid id, DateTime dataCadastro)
        {
            Id = id;
            DataCadastro = dataCadastro;
        }

        public DateTime BrazilianDateTime()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo horaBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, horaBrasilia);
        }
    }
}
