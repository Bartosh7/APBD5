namespace projekt;

public class AnimalsDb : IAnimalsDb
{
    private readonly ICollection<Animal> _animals;

    public AnimalsDb()
    {
        _animals = new List<Animal>
        {
            new Animal(1, "Reks", "Pies", 25, "Brązowy"),
            new Animal(2, "Hawkeye", "Pies", 30, "Czarny i biały"),
            new Animal(3, "Fluffy", "Kot", 5, "Szary")
        };
    }

    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public Animal? GetById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public void Delete(Animal animal)
    {
        _animals.Remove(animal);
    }

    public void Update(Animal existingAnimal, Animal newAnimalData)
    {
        if (existingAnimal != null)
        {
            existingAnimal.Id = newAnimalData.Id;
            existingAnimal.Name = newAnimalData.Name;
            existingAnimal.Category = newAnimalData.Category;
            existingAnimal.Weight = newAnimalData.Weight;
            existingAnimal.Color = newAnimalData.Color;
        }
        
    }
}