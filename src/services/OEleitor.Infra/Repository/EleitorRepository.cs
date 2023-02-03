using AutoMapper;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Context;
using OEleitor.Infra.Repository.Base;

namespace OEleitor.Infra.Repository
{
    public class EleitorRepository : BaseRepository<Eleitor>, IEleitorRepository
    {
        private readonly OEleitorDbContext _context;

        public EleitorRepository(OEleitorDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

    }
}
