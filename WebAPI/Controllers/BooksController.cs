using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private static List<Book> books = new List<Book>();

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(Guid id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if (book is null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(books);
    }

    [HttpPost]
    public IActionResult Create(BookDto dto)
    {
        var book = Book.Create(dto.title, dto.author);
        books.Add(book);
        return Created(nameof(book.Id), book);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(Guid id)
    {
        var book = books.FirstOrDefault((x) => x.Id == id);
        if(book is null) 
        {
            return NotFound();
        }
        books.Remove(book);
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(Guid id, BookDto dto)
    {
        var book = books.FirstOrDefault((x) => x.Id == id);
        if (book is null)
        {
            return NotFound();
        }
        book.Update(dto.title, dto.author);

        return NoContent();
    }
}
