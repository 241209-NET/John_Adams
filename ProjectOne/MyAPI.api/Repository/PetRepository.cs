using PetTracker.API.Model;

namespace PetTracker.API.Repository;

public class PetRepository : IPetRepository
{
    //Need the database object to work with
    public Pet CreatePet(Pet newPet)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> GetAllPets()
    {
        throw new NotImplementedException();
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