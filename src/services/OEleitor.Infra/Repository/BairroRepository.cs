using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Repository.Base;
using Dapper;
using OEleitor.Domain.Dtos;
using OEleitor.Infra.Context;

namespace OEleitor.Infra.Repository
{
    public class BairroRepository : BaseRepository<Bairro>, IBairroRepository
    {
        private readonly OEleitorDbContext _context;

        public BairroRepository(OEleitorDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        //public async Task<PagedResult<BairroDto>> ObterTodos(int pageSize, int pageIndex, string query = null)
        //{
        //    var page = new PagedResult<BairroDto> { 
        //        PageSize = pageSize,
        //        PageIndex = pageIndex,
        //        TotalResults = await Connection
        //        @$"SELECT * FROM Bairros 
        //              WHERE (@Nome IS NULL OR BairroNome LIKE '%@Nome%') 
        //              ORDER BY BairroNome 
        //              LIMIT {pageSize} 
        //              OFFSET {(pageIndex - 1) * pageSize}";
        //              //SELECT COUNT(Id) FROM Bairros 
        //              //WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')";

        //    var multi = await _context.Database.GetDbConnection()
        //        .QueryMultipleAsync(sql, new { Nome = query });

        //    var bairros = multi.Read<Bairro>();
        //    var total = multi.Read<int>().FirstOrDefault();

        //    return new PagedResult<Bairro>()
        //    {
        //        List = bairros,
        //        TotalResults = total,
        //        PageIndex = pageIndex,
        //        PageSize = pageSize,
        //        Query = query
        //    };

        //}
    }
}
