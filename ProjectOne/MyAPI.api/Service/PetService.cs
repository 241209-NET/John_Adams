using PetTracker.API.Model;

namespace PetTracker.API.Service;

public class PetService : IPetService
{
    public Pet CreatePet(Pet newPet)
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

    IEnumerable<Pet> IPetService.GetAllPets()
    {
        throw new NotImplementedException();
    }
}