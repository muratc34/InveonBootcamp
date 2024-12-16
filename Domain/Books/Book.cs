using Domain.Core;
using System.Text.Json.Serialization;

namespace Domain.Books;

public sealed class Book : Entity
{
    [JsonConstructor]
    public Book(string title, string author, int publicationYear, string isbn, string genre, string publisher, int pageCount, string language, string summary, int availableCopies) : base()
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        ISBN = isbn;
        Genre = genre;
        Publisher = publisher;
        PageCount = pageCount;
        Language = language;
        Summary = summary;
        AvailableCopies = availableCopies;
    }
    public Book()
    { }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public int PublicationYear { get; private set; }
    public string ISBN { get; private set; }
    public string Genre { get; private set; }
    public string Publisher { get; private set; }
    public int PageCount { get; private set; }
    public string Language { get; private set; }
    public string Summary { get; private set; }
    public int AvailableCopies { get; private set; }

    public static Book Create(string title, string author, int publicationYear, string isbn, string genre, string publisher, int pageCount, string language, string summary, int availableCopies)
    {
        return new Book(title, author, publicationYear, isbn, genre, publisher, pageCount, language, summary, availableCopies);
    }
}
