using OEleitor.Infra.CrossCurtting.DomainObjects.Interfaces;
using OEleitor.Infra.CrossCurtting.Messages;

namespace OEleitor.Infra.CrossCurtting.DomainObjects
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

        private List<Event> _notificacoes;

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
