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
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> GetPetByName(string name)
    {
        throw new NotImplementedException();
    }
}