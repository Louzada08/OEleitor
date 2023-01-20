using System.Threading.Tasks;
using OEleitor.Domain.Messages;
using OEleitor.Domain.Validation;

namespace OEleitor.Domain.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        public Task PublishEvent<T>(T evnt) where T : Event;
        public Task<ValidationResultBag> SendCommand<T>(T command) where T : Command;
    }
}
