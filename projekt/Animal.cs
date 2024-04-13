namespace projekt;

public class Animal
{
    public int Id { set; get; }
    public string Name { set; get; }
    public string Category { set; get; }
    public double Weight { set; get; }
    public string Color { set; get; }

    public Animal(int id, string name, string category, double weight, string color)
    {
        Id = id;
        Name = name;
        Category = category;
        Weight = weight;
        Color = color;
    }
    
    
    
}