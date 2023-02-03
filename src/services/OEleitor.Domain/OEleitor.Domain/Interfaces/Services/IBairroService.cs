using OEleitor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OEleitor.Domain.Interfaces.Services
{
    public interface IBairroService
    {
        Task<IEnumerable<Bairro>> ObterTodos();
    }
}
