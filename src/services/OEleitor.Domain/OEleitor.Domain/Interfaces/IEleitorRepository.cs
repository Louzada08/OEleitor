using OEleitor.Domain.Entities;
using OEleitor.Infra.CrossCurtting.Data;
using OEleitor.Infra.CrossCurtting.DomainObjects.Interfaces;

namespace OEleitor.Domain.Interfaces
{
    public interface IEleitorRepository : IBaseRepository<Eleitor>, IAggregateRoot
    {
    }
}
