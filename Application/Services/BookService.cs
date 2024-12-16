using Application.Abstractions.Cache;
using Application.Abstractions.Data;
using Application.Core.Exceptions;
using Application.DTOs;
using Domain.Books;
using Domain.Core;
using System.Collections.Immutable;

namespace Application.Services;

public interface IBookService
{
    public Task<GetBookDto> GetBookById(int id);
    public Task<PagedResult<GetBooksDto>> GetBooks(int pageIndex, int pageSize, CancellationToken cancellationToken);
}

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly ICacheService _cacheService;

    public BookService(IBookRepository bookRepository, ICacheService cacheService)
    {
        _bookRepository = bookRepository;
        _cacheService = cacheService;
    }

    public async Task<GetBookDto> GetBookById(int id)
    {
        var entity = 
            await _bookRepository.GetAsync(x => x.Id == id) ?? 
            throw new NotFoundException("Aradığınız kitap bulunamadı!");

        return new GetBookDto(entity.Id, entity.Title, entity.Author, entity.PublicationYear, entity.ISBN, entity.Genre, entity.Publisher, entity.PageCount, entity.Language, entity.Summary, entity.AvailableCopies);
    }

    public async Task<PagedResult<GetBooksDto>> GetBooks(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var totalBooks = await _bookRepository.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

        var data = await _cacheService.GetAsync<List<Book>>($"GetBooks-Page:{pageIndex}");
        var books = new List<Book>();
        if (data is null)
        {
            books = await _bookRepository.GetAllByPagingAsync(null, pageIndex, pageSize, cancellationToken);
            await _cacheService.SetAsync($"GetBooks-Page:{pageIndex}", books, TimeSpan.FromMinutes(20));
        }
        else
        {
            books = data;
        }
        
        var bookDtos = books.Select(x => new GetBooksDto(x.Id, x.Title, x.Author, x.PublicationYear, x.ISBN)).ToList();

        return new PagedResult<GetBooksDto>
        {
            Books = bookDtos,
            CurrentPage = pageIndex,
            TotalPages = totalPages,
            TotalCount = totalBooks
        };
    }
}
