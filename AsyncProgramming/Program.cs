using AsyncProgramming.AsyncAwaitExample;

//var func = new AsyncFunction();

#region Senkron
//Console.WriteLine("Senkron fonksiyon çalışıyor");
//var list = func.GetAll();
//Console.WriteLine($"Senkron fonksiyon işini bitirdi: {list.Count} makale üretildi.");
#endregion

#region Asenkron
//Console.WriteLine("Asenkron Fonksiyon çalışıyor");
//var listAsync = await func.GetAllAsync();
//Console.WriteLine($"Asenkron fonksiyon işini bitirdi: {listAsync.Count} makale üretildi.");
#endregion

#region AsyncAwait
//var asyncAwait = new AsyncAwait();

//await asyncAwait.DownloadFilesAsync(new List<string>() {"Dosya 1", "Dosya 2", "Dosya 3", "Dosya 4", "Dosya 5" });
#endregion

#region Task Class Methods
var task1 = Task.Run(()
=> {
    //var cancellation = new CancellationTokenSource();
    //cancellation.Cancel();
    //await Task.FromCanceled(cancellation.Token);

    Task.Delay(1000);
    Console.WriteLine("Task 1 yapıldı.");
});
var task2 = Task.Run(()
=> {
    //await Task.FromException(new InvalidOperationException("Bir hata meydana geldi."));

    Task.Delay(3000);
    Console.WriteLine("Task 2 yapıldı.");

});
var task3 = Task.Run(()
=> {
    Task.Delay(2000);
    return Task.FromResult("Task 3 bitti.");
});
var task4 = Task.Run(()
=> {
    Task.Delay(3000);
    return Task.FromResult("Task 4 bitti.");
});

#region WhenAny
//var completedTask = await Task.WhenAny(task3, task4);
//Console.WriteLine($"İlk tamamlanan taskın sonucu: {await completedTask}");
#endregion

#region WhenAll
//await Task.WhenAll(task1, task2);
//Console.WriteLine("Bütün tasklar tamamlandı.");
#endregion

#region WaitAll
Task.WaitAll(task1, task2);
Console.WriteLine("Bütün tasklar tamamlandı.");
#endregion

#region WaitAny
var completedTask = Task.WaitAny(task1, task2);
Console.WriteLine($"İlk tamamlanan task: {completedTask}");
#endregion
#endregion