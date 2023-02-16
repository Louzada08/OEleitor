using System.Collections.Generic;

namespace OEleitor.Domain.Entities
{
    public class PagedResult<T>
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageTotalItems { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}