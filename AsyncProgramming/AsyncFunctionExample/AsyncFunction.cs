namespace AsyncProgramming.AsyncFunctionExample;

public class AsyncFunction
{
    public List<Article> GetAll()
    {
        var list = new List<Article>();

        var articles = Enumerable.Range(0, 100).Select(i =>
        {
            Thread.Sleep(100);
            return new Article($"Article {i}");
        });
        return articles.ToList();
    }

    public async Task<List<Article>> GetAllAsync()
    {
        var list = new List<Article>();

        var tasks = Enumerable.Range(0, 100).Select(async i =>
        {
            await Task.Delay(100);
            return new Article($"Article {i}");
        });
        var articles = await Task.WhenAll(tasks);
        return articles.ToList();
    }
}
