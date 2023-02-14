using OEleitor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OEleitor.Domain.Interfaces.Services
{
    public interface IBairroService
    {
        Task<IEnumerable<Bairro>> ObterTodos();
        Task<Bairro> ObterPorId(Guid? id);
    }
}
