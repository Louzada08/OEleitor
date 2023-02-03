using FluentValidation.Results;
using OEleitor.Infra.CrossCurtting.Messages;
using System.Threading.Tasks;

namespace OEleitor.Domain.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        public Task PublicarEvento<T>(T evnt) where T : Event;
        public Task<ValidationResult> EnviarComando<T>(T command) where T : Command;
    }
}
