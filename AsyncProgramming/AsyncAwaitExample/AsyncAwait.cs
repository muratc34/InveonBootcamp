namespace AsyncProgramming.AsyncAwaitExample;

public class AsyncAwait
{
    public async Task DownloadFilesAsync(List<string> files)
    {
        List<Task> downloadTasks = [];

        foreach (var file in files)
        {
            downloadTasks.Add(Task.Run(async() =>
            {
                Console.WriteLine($"{file} indirilmeye başlandı...");
                await Task.Delay(new Random().Next(1000, 3000));
                Console.WriteLine($"{file} başarıyla indirildi.");
            }));
        }
        try
        {
            await Task.WhenAll(downloadTasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dosyaların bazıları indirilemedi. {ex}");
            throw;
        }
    }
}
