using Dapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OEleitor.Application.Query.Interface;
using OEleitor.Domain.Dtos;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Filtros;
using OEleitor.Infra.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OEleitor.Application.Query
{
    public class BairroQuery : QueryBaseReadOnly, IBairroQuery
    {
        public BairroQuery(IConfiguration config) : base(config)
        {
        }

        public async Task<PagedResult<BairroDto>> ObterPaginadoTodos(int pageSize, int pageIndex, BairroQueryFiltro query = null)
        {
            SqlBuilder.Template selector;
            var builder = new SqlBuilder();

            var sqlStr = @"SELECT * FROM  ""Bairros""
                                             /**where**/
                                            /**orderby**/";

            selector = builder.AddTemplate(sqlStr);

            if (query.NomeBairro is not null)
                builder.Where(@"UPPER(BairroNome) LKE @nomeBairro", new { nomeBairro = $"%{query.NomeBairro.ToUpper()}%" });

            builder.Select("PageIndex", new { pageIndex });
            builder.Select("PageSize", new { pageSize });

            var page = new PagedResult<BairroDto>
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

            var colunaSort = @"""BairroNome""";
            builder.AddParameters(new { offset = (pageIndex - 1) * pageSize, nrows = pageSize });
            builder.OrderBy($"{colunaSort} ASC");

            page.List = await Connection.QueryAsync<BairroDto>($@"{selector.RawSql} OFFSET @offset ROWS FETCH NEXT @nrows ROWS ONLY", selector.Parameters);

            return page;
        }

    }
}
