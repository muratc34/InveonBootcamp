namespace Domain.Core;

public class PagedResult<TEntity>
{
    public List<TEntity> Books { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}
