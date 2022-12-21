using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Data.Context;
using OEleitor.Infra.Data.Repository.Base;

namespace OEleitor.Infra.Data.Repository
{
    public class BairroRepository : Repository<Bairro>, IBairroRepository
    {
        private readonly OEleitorDbContext _context;

        public BairroRepository(OEleitorDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
