using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
    {
        var result = await _bookService.GetBooks(pageIndex, pageSize, CancellationToken.None);

        return View(result);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var book = await _bookService.GetBookById(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }
}
