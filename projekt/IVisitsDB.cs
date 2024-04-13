namespace projekt;

public interface IVisitsDB
{
    public ICollection<Visit> GetAllAnimalVisits(int id);
    public void Add(Visit visit);
}