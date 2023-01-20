using OEleitor.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OEleitor.Domain.Interfaces.Services
{
    public interface IEleitorService
    {
        Task<Eleitor> ObterPorId(Guid id);
        Task<Eleitor> AdicionaEleitor(Eleitor eleitor);
    }
}
