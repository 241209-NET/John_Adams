using PetTracker.API.Data;
using PetTracker.API.Model;

namespace PetTracker.API.Repository;
//Just talks to the data base
public class PetRepository : IPetRepository
{
    //Needs the database object to work with.
    private readonly PetContext _petContext;

    public PetRepository(PetContext petContext) => _petContext = petContext;
    public Pet CreatePet(Pet newPet)
    {
        _petContext.Pets.Add(newPet);
        _petContext.SaveChanges();
        return newPet;
    }

    public IEnumerable<Pet> GetAllPets()
    {
        return _petContext.Pets.ToList();
    }

    public Pet? GetPetById(int id)
    {
        return _petContext.Pets.Find(id);
    }
    public Pet? DeletePetById(int id)
    {
        var pet = GetPetById(id);
        _petContext.Pets.Remove(pet!);
        _petContext.SaveChanges();
        return pet;
    }

    public IEnumerable<Pet> GetPetByName(string name)
    {
        throw new NotImplementedException();
        //var pet = _petContext.Pets.Where(p => p.Name.Equals(name)).ToList();
    }
}