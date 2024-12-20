using PetTracker.API.Model;
using PetTracker.API.Service;
using PetTracker.API.Repository;
using Moq;

namespace PetTracker.TEST;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Mock<IPetRepository> mockRepo = new();
        PetService petService = new(mockRepo.Object);

        List<Pet> petList = [
            new Pet{Id = 1, Name = "Everest"},
            new Pet{Id = 2, Name = "Latte"},
            new Pet{Id = 3, Name = "Kai"},
            new Pet{Id = 4, Name = "Peanut"},

        ];
        Pet pet = new Pet{Id = 5, Name = "Roov"};

        //mockRepo.Setup(repo => repo.CreateNewPet()).
    }
}
