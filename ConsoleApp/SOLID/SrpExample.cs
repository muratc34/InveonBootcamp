namespace ConsoleApp.SOLID.SrpExample;


#region Before SRP

//public class Blog
//{
//    public int Id { get; set; }
//    public string Title { get; set; }
//    public string Content { get; set; }


//    public void SaveBlogToDatabase()
//    {
//        Console.WriteLine("Blog veritabanına kaydedildi.");
//    }

//    public string GenerateSlug()
//    {
//        return Title.Replace(" ", "-").ToLower();
//    }

//    public void SendEmail(string emailAddress)
//    {
//        Console.WriteLine($"Blog '{Title}' şu adrese e-posta olarak gönderildi: {emailAddress}");
//    }

//}
#endregion

#region After SRP
public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

public class BlogRepository
{
    public void SaveToDatabase()
    {
        Console.WriteLine("Blog veritabanına kaydedildi.");
    }
}

public class BlogService
{
    public string GenerateSlug(Blog blog)
    {
        return blog.Title.Replace(" ", "-").ToLower();
    }
}

public class EmailService
{
    public void SendBlogByEmail(Blog blog, string emailAddress)
    {
        Console.WriteLine($"Blog '{blog.Title}' şu adrese e-posta olarak gönderildi: {emailAddress}");
    }
}

#endregion