namespace ConsoleApp.SOLID.LspExample;

#region Before LSP
//public class Vehicle
//{
//    public virtual void Drive()
//    {
//        Console.WriteLine("Araç sürülüyor.");
//    }

//    public virtual void Fly()
//    {
//        Console.WriteLine("Araç uçuyor.");
//    }
//}

//public class Car : Vehicle
//{
//    public override void Fly()
//    {
//        throw new InvalidOperationException("Arabalar uçamaz");
//    }
//}

//public class Airplane : Vehicle
//{

//}
#endregion

#region After LSP
public interface IDrivable
{
    void Drive();
}
public interface IFlyable
{
    void Fly();
}

public abstract class Vehicle
{

}
public class Car : Vehicle, IDrivable
{
    public void Drive()
    {
        Console.WriteLine("Araba sürülüyor.");
    }
}

public class Airplane : Vehicle, IDrivable, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Uçak uçuyor.");
    }

    public void Drive()
    {
        Console.WriteLine("Uçak sürülüyor.");
    }
}
#endregion