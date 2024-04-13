namespace projekt;

public class VisitsDb : IVisitsDB
{
    private ICollection<Visit> _visits;

    public VisitsDb()
    {
        _visits = new List<Visit>()
        {
            new Visit(new DateTime(2023, 1, 2), new Animal(1, "Reks", "Pies", 25, "Brązowy"), "Badanie ogólne", 50.0),
            new Visit(new DateTime(2023, 1, 2), new Animal(2, "Reksio", "Kot", 25, "Zielony"), "Badanie wzroku", 29.0),
            new Visit(new DateTime(2023, 1, 2), new Animal(3, "Reksek", "Chomik", 25, "Czerwony"), "Badanie moczu",
                30.0)
        };
    }

    public ICollection<Visit> GetAllAnimalVisits(int id)
    {
        return _visits.Where(visit => visit.Animal.Id == id).ToList();
    }

    public void Add(Visit visit)
    {
        _visits.Add(visit);
    }
}