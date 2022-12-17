using MediatR;
using OEleitor.Domain.Message;

namespace OEleitor.Domain.Interfaces
{
    public interface ICommand : IRequest<CommandResult>, IBaseRequest
    {
    }
}
