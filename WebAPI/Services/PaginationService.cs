using WebAPI.Models;

namespace WebAPI.Services;

public class PaginationService
{
    public Pagination<Fruit> GetPagination(List<Fruit> fruitList, int pageNum, int pageSize)
    {
        if (pageSize < 5)
        {
            pageSize = 5;
        }
        if (pageSize > fruitList.Count)
        {
            pageSize = fruitList.Count;
        }
        var totalPages = (int)Math.Ceiling(fruitList.Count / (double)pageSize);

        if (pageNum < 1)
        {
            pageNum = 1;
        }
        if (pageNum > totalPages)
        {
            pageNum = totalPages;
        }

        var fruits = fruitList
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        return new Pagination<Fruit>(fruits, pageNum, totalPages);
    }
}

public interface IPaginationService
{
    public Pagination<Fruit> GetPagination(List<Fruit> fruitList, int pageNum, int pageSize);
}