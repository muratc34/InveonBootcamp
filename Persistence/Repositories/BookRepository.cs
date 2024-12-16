using Application.Abstractions.Data;
using Domain.Books;
using Persistence.Context;

namespace Persistence.Repositories;

public sealed class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) 
        : base(context)
    {
    }
}
