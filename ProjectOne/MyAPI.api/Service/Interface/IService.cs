using PetTracker.API.Model;

namespace PetTracker.API.Service;

public interface IPetService
{
    Pet CreatePet(Pet newPet);
    IEnumerable<Pet> GetAllPets();
    Pet? GetPetById(int id);
    IEnumerable<Pet> GetPetByName(string name);
    
}

public interface IOwnerService
{

}