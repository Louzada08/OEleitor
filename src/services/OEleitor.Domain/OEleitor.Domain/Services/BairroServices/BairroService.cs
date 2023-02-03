using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backoffice.Core.Services.PurchaseForms;

public class BairroService : IBairroService
{
    private readonly IBairroRepository _repository;

    public BairroService(IBairroRepository repository)
    {
        _repository = repository;
    }

    public async Task<Bairro> ObterPorId(Guid id)
    {
        var queryCustomer = await _repository.GetByIdAsync(id);

        if (queryCustomer is null) throw new Exception("Eleitor não encontrado.");

        return queryCustomer;
    }

    public async Task<IEnumerable<Bairro>> ObterTodos()
    {
       return await _repository.GetAllAsync();
    }
}