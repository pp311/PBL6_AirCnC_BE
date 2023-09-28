namespace AirCnC.Application.Commons;

public class PagedList<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    
    public IEnumerable<T> Data { get; set; }     
    
     public PagedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
     {
         Data = items;
         TotalCount = count;
         CurrentPage = pageIndex;
         PageSize = pageSize;
         TotalPages = (int)Math.Ceiling(count / (double)pageSize);
     }
}