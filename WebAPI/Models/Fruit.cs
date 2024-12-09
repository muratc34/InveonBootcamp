namespace WebAPI.Models;

public class Fruit
{
    public Fruit(string name, string color)
    {
        Id = Guid.NewGuid();
        Name = name; 
        Color = color;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Color{ get; set; }
}

