using MediatR;

namespace OEleitor.Application.Core.Interfaces
{
    public interface ICommand : IRequest<CommandResult>, IBaseRequest
    {
    }
}
