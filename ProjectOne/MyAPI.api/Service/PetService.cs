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
        if(id < 1) return null;

        return _petRepository.GetPetById(id);
    }

    public IEnumerable<Pet> GetPetByName(string name)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Pet> IPetService.GetAllPets()
    {
        return _petRepository.GetAllPets();
    }

    public Pet? DeletePetById(int id)
    {
        var pet = GetPetById(id);
        if(pet is not null) _petRepository.DeletePetById(id);
        return pet;
    }
}