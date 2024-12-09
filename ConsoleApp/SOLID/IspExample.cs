namespace ConsoleApp.SOLID.IspExample;

#region Before Isp
//public interface IMachine
//{
//    void Start();
//    void Stop();
//    void MakeCoffee(); 
//    void HeatFood(); 
//    void PrintDocument();
//}

//public class CoffeeMachine : IMachine
//{
//    public void HeatFood()
//    {
//        throw new NotImplementedException();
//    }

//    public void MakeCoffee()
//    {
//        Console.WriteLine("Kahve yapılıyor.");
//    }

//    public void PrintDocument()
//    {
//        throw new NotImplementedException();
//    }

//    public void Start()
//    {
//        Console.WriteLine("Kahve makinesi çalıştırılıyor.");
//    }

//    public void Stop()
//    {
//        Console.WriteLine("Kahve makinesi durduruluyor.");
//    }
//}

//public class MicrowaveMachine : IMachine
//{
//    public void HeatFood()
//    {
//        Console.WriteLine("Yemek ısıtılıyor.");
//    }

//    public void MakeCoffee()
//    {
//        throw new NotImplementedException();
//    }

//    public void PrintDocument()
//    {
//        throw new NotImplementedException();
//    }

//    public void Start()
//    {
//        Console.WriteLine("Mikrodalga çalıştırılıyor.");
//    }

//    public void Stop()
//    {
//        Console.WriteLine("Mikrodalga durduruluyor.");
//    }
//}

//public class Printer : IMachine
//{
//    public void HeatFood()
//    {
//        throw new NotImplementedException();
//    }

//    public void MakeCoffee()
//    {
//        throw new NotImplementedException();
//    }

//    public void PrintDocument()
//    {
//        Console.WriteLine("Doküman yazdırılıyor.");
//    }

//    public void Start()
//    {
//        Console.WriteLine("Yazıcı çalıştırılıyor.");
//    }

//    public void Stop()
//    {
//        Console.WriteLine("Yazıcı durduruluyor.");
//    }
//}
#endregion

#region After Isp
public interface IStartable
{
    void Start();
    void Stop();
}

public interface ICoffeeMaker
{
    void MakeCoffee();
}

public interface IPrinter
{
    void PrintDocument();
}

public interface IFoodHeater
{
    void HeatFood();
}

public class CoffeeMachine : IStartable, ICoffeeMaker
{
    public void Start()
    {
        Console.WriteLine("Kahve makinesi çalıştırılıyor.");
    }

    public void Stop()
    {
        Console.WriteLine("Kahve makinesi durduruluyor.");
    }

    public void MakeCoffee()
    {
        Console.WriteLine("Kahve yapılıyor.");
    }
}

public class Microwave : IStartable, IFoodHeater
{
    public void Start()
    {
        Console.WriteLine("Mikrodalga çalıştırılıyor.");
    }

    public void Stop()
    {
        Console.WriteLine("Mikrodalga durduruluyor.");
    }

    public void HeatFood()
    {
        Console.WriteLine("Yemek ısıtılıyor.");
    }
}

public class Printer : IStartable, IPrinter
{
    public void Start()
    {
        Console.WriteLine("Yazıcı çalıştırılıyor.");
    }

    public void Stop()
    {
        Console.WriteLine("Yazıcı durduruluyor.");
    }

    public void PrintDocument()
    {
        Console.WriteLine("Doküman yazdırılıyor.");
    }
}
#endregion