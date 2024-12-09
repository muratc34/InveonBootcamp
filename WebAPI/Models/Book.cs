namespace WebAPI.Models;

public class Book
{
    public Book(Guid id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }

    public static Book Create(string title, string author)
    {
        return new Book(Guid.NewGuid(), title, author);
    }

    public void Update(string title, string author)
    {
        Title = title;
        Author = author;
    }
}
