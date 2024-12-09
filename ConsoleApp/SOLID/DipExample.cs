namespace ConsoleApp.SOLID.DipExample;

#region Before DIP
//public class EmailService
//{
//    public void SendEmail(string message)
//    {
//        Console.WriteLine("Email gönderildi: " + message);
//    }
//}

//public class Notification
//{
//    private EmailService _emailService;

//    public Notification()
//    {
//        _emailService = new EmailService();
//    }

//    public void Notify(string message)
//    {
//        _emailService.SendEmail(message);
//    }
//}
#endregion

#region After DIP
public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Email gönderildi: " + message);
    }
}

public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}
#endregion