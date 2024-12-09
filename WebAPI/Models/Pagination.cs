namespace WebAPI.Models;

public class Pagination<T>
{
    public Pagination(List<T> datas, int pageNumber, int totalPages)
    {
        Datas = datas;
        PageNumber = pageNumber;
        TotalPages = totalPages;
    }

    public List<T> Datas { get; set; }
    public int PageNumber { get; }
    public int TotalPages { get; }
}
