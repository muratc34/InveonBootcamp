namespace ConsoleApp.SOLID.OcpExample;

#region Before OCP
//public class PaymentProcessor
//{
//    public void ProcessPayment(string paymentType)
//    {
//        if (paymentType == "CreditCard")
//        {
//            Console.WriteLine("Processing Credit Card Payment...");
//        }
//        else if (paymentType == "Cash")
//        {
//            Console.WriteLine("Processing Cash Payment...");
//        }
//        else
//        {
//            throw new NotSupportedException("Payment method not supported.");
//        }
//    }
//}
#endregion

#region After OCP
public class PaymentProcessor
{
    public void ProcessPayment(IPaymentMethod paymentMethod) => paymentMethod.ProcessPayment();
}

public interface IPaymentMethod
{
    void ProcessPayment();
}

public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing Credit Card Payment...");
    }
}

public class CashPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing Cash Payment...");
    }
}

public class CryptoPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing Cryptocurrency Payment...");
    }
}
#endregion