namespace projekt;

public class Visit
{
    public DateTime Date { set; get; }
    public Animal Animal { set; get; }
    public string Description { set; get; }
    public double Price { set; get; }

    public Visit(DateTime date, Animal animal, string description, double price)
    {
        Date = date;
        Animal = animal;
        Description = description;
        Price = price;
    }
}