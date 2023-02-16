using Dapper;
using Microsoft.Extensions.Configuration;
using OEleitor.Application.Query.Interface;
using OEleitor.Domain.Dtos;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Filtros;
using OEleitor.Infra.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace OEleitor.Application.Query
{
    public class EleitorQuery : QueryBaseReadOnly, IEleitorQuery
    {
        public EleitorQuery(IConfiguration config) : base(config)
        {
        }

        public async Task<PagedResult<EleitorDto>> ObterPaginadoTodos(int pageSize, int pageIndex, EleitorQueryFiltro query = null)
        {
            SqlBuilder.Template selector;
            var builder = new SqlBuilder();

            var sqlStr = @"SELECT *, ""Id"" as EleitorId, ""BairroId"" as BairroId,
                                  ""Endereco_Logradouro"" as Logradouro, 
                                  ""Endereco_Complemento"" as Complemento, 
                                  ""Endereco_Cidade"" as Cidade, 
                                  ""Endereco_Estado"" as Estado,                                   
                                  ""Endereco_Cep"" as Cep, 
                                  ""Endereco_Numero"" as Numero, 
                                  ""Fone1"" as Fone1, 
                                  ""Fone1TemWhatsapp"" as Fone1TemWhatsapp, 
                                  ""Fone2"" as Fone2, 
                                  ""Fone2TemWhatsapp"" as Fone2TemWhatsapp 
                           FROM  ""Eleitores"" 
                                             /**where**/
                                            /**orderby**/";

            selector = builder.AddTemplate(sqlStr);

            if (query.Nome is not null)
                builder.Where(@"UPPER(Nome) LKE @nomecompleto", new { nomeCompleto = $"%{query.Nome.ToUpper()}%" });

            builder.Select("PageIndex", new { pageIndex });
            builder.Select("PageSize", new { pageSize });

            var page = new PagedResult<EleitorDto>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                PageCount = await Connection.QueryFirstAsync<int>
                (
                    @$"SELECT (CASE 
                                    WHEN (COUNT(*) / :PageSize) <> TRUNC(COUNT(*) / :PageSize, 0) THEN TRUNC(COUNT(*) / :PageSize, 0) + 1
                                    ELSE (COUNT(*) / :PageSize)
                               END
                              ) PageCount
                          FROM ({selector.RawSql} LIMIT 1000) T",
                    selector.Parameters
                    ),
                PageTotalItems = await Connection.QueryFirstAsync<int>($@"SELECT COUNT(*) PageTotalItems FROM ({selector.RawSql} LIMIT 1000) T", selector.Parameters)
            };

            var colunaSort = @"""Nome""";
            builder.AddParameters(new { offset = (pageIndex - 1) * pageSize, nrows = pageSize });
            builder.OrderBy($"{colunaSort} ASC");

            page.List = await Connection.QueryAsync<EleitorDto>($@"{selector.RawSql} OFFSET @offset ROWS FETCH NEXT @nrows ROWS ONLY", selector.Parameters);

            var bairro = await Connection.QueryAsync<BairroDto>($@"
                SELECT b.""Id"", ""BairroNome"" FROM  ""Bairros"" b
                    INNER JOIN ""Eleitores"" e ON b.""Id"" = e.""BairroId""");

            page.List.ToList().ForEach(x => x.Bairro = bairro.Where(b => b.Id.Equals(x!.BairroId)).FirstOrDefault());

            var dependentes = await Connection.QueryAsync<DependenteDto>($@"
                SELECT d.""Id"", d.""EleitorId"", d.""Nome"", d.""Fone"", * FROM  ""Dependentes"" d
                    INNER JOIN ""Eleitores"" e ON d.""EleitorId"" = e.""Id""");

            page.List.ToList().ForEach(x => x.Dependentes = dependentes.Where(d => d.EleitorId.Equals(x.EleitorId)));

            return page;
        }

    }
}
