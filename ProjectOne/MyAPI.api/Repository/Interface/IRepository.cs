using PetTracker.API.Model;

namespace PetTracker.API.Repository;

public interface IPetRepository
{
    //CRUD operations here
    Pet CreatePet(Pet newPet);
    IEnumerable<Pet> GetAllPets();
    Pet? GetPetById(int id);
    IEnumerable<Pet> GetPetByName(string name);

    Pet? DeletePetById(int id);
    
}