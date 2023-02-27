using Microsoft.EntityFrameworkCore;
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
        var queryEleitor = await _repository.GetAsync(x => x.Id.Equals(id),
            x => x.Include(i => i.Dependentes)
                  .Include(i => i.Bairro));

        if (queryEleitor is null) throw new Exception("Eleitor não encontrado.");

        return queryEleitor;
    }

    public async Task<Eleitor> AdicionaEleitor(Eleitor eleitor)
    {
        var ret = await _repository.AddAsync(eleitor);
        await _repository.UnitOfWork.CommitAsync();
        return ret;
    }
}