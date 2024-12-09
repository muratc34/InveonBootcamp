namespace AsyncProgramming.AsyncFunctionExample;

public class Article
{
    public Article(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
}
