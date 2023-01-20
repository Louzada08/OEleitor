﻿using AutoMapper;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Context;
using OEleitor.Infra.Repository.Base;

namespace OEleitor.Infra.Repository
{
    public class BairroRepository : BaseRepository<Bairro>, IBairroRepository
    {
        private readonly OEleitorDbContext _context;

        public BairroRepository(OEleitorDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        IUnitOfWork UnitOfWork => _context;
    }
}
