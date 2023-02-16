namespace OEleitor.WebApp.MVC.Models
{
    public class PagedViewModel<T> : IPagedList where T : class
    {
        public string ReferenceAction { get; set; }
        public IEnumerable<T> List { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageTotalItems { get; set; }
        public double PageCount => Math.Ceiling((double)PageTotalItems / PageSize);
        public string Query { get; set; }
    }
    public interface IPagedList
    {
        public string ReferenceAction { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageTotalItems { get; set; }
        public double PageCount { get; }
        public string Query { get; set; }
    }
}