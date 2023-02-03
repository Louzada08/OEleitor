using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Backoffice.Core.Services.PurchaseForms;

public class EleitorService : IEleitorService
{
    private readonly IEleitorRepository _repository;

    public EleitorService(IEleitorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Eleitor> ObterPorId(Guid id)
    {
        var queryCustomer = await _repository.GetByIdAsync(id);

        if (queryCustomer is null) throw new Exception("Eleitor não encontrado.");

        return queryCustomer;
    }

    public async Task<Eleitor> AdicionaEleitor(Eleitor eleitor)
    {
        var ret = await _repository.AddAsync(eleitor);
        await _repository.UnitOfWork.CommitAsync();
        return ret;
    }
}