using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using OEleitor.Domain.Entities;
using System.Data;

namespace OEleitor.Infra.Repository.Base
{
    public abstract class QueryBaseReadOnly
    {
        private readonly IConfiguration _config;

        protected QueryBaseReadOnly(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection => new NpgsqlConnection(_config.GetConnectionString("OEleitorConnection"));

        public async Task<PagedResult<T>> FindAllPagedAsync<T>(SqlBuilder builder, SqlBuilder.Template selector, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 10;

            var page = new PagedResult<T>() { PageIndex = pageNumber.Value, PageSize = pageSize.Value };

            builder.Select("PageIndex", new { pageNumber });
            builder.Select("PageSize", new { pageSize });

            page.PageCount = await Connection.QueryFirstAsync<int>($@"
                select (case when round(cast(count(*) as float) / cast(@PageSize as float), 0) <> cast(count(*) as float) / cast(@PageSize as float) then round(cast(count(*) as float) / cast(@PageSize as float), 0) + 1 else round(cast(count(*) as float) / cast(@PageSize as float), 0) end)
                PageCount from  ({selector.RawSql}) t", selector.Parameters);

            page.PageTotalItems = await Connection.QueryFirstAsync<int>($@"select count(*) PageTotalItems from ({selector.RawSql}) t", selector.Parameters);

            page.List = await Connection.QueryAsync<T>($@"
            {selector.RawSql} offset @offset rows fetch next @nrows rows only)", selector.Parameters);

            return page;
        }
    }
}
