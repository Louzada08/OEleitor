using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Data.Context;
using OEleitor.Infra.Data.Repository.Base;

namespace OEleitor.Infra.Data.Repository
{
    public class EleitorRepository : Repository<Eleitor>, IEleitorRepository
    {
        private readonly OEleitorDbContext _context;

        public EleitorRepository(OEleitorDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
