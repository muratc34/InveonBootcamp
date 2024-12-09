namespace WebAPI.Models;

public class Car
{
    public Car(string brand, string modelName, int modelYear)
    {
        Id = Guid.NewGuid();
        Brand = brand;
        ModelName = modelName;
        ModelYear = modelYear;
    }
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public int ModelYear { get; set; }
}
