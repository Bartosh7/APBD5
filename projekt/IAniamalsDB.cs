namespace projekt;

public interface IAnimalsDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetById(int id);
    public void Add(Animal animal);
    public void Delete(Animal animal);
    public void Update(Animal existingAnimal, Animal newAnimalData);
}