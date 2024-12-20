using PetTracker.API.Model;
using PetTracker.API.Repository;

namespace PetTracker.API.Service;
//Business Logic here, checking for variable usability etc.
public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService (IPetRepository petRepository) => _petRepository = petRepository;
    public Pet CreatePet(Pet newPet)
    {
        var pet = _petRepository.CreatePet(newPet);
        return pet;
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
        return _petRepository.GetAllPets();
    }
}