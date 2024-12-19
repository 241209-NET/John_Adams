using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PetTracker.API.Model;

namespace PetTracker.API.Controller;

[Route("api/[controller]")]//Annotation for route of the controller
[ApiController]//Annotation for API Controller for ASPNET
public class PetController : ControllerBase
{
    List<Pet> petList = [
        new Pet{Id = 1, Name = "Everest", Type = "Dog"},
        new Pet{Id = 2, Name = "Latte", Type = "Dog"},
        new Pet{Id = 3, Name = "Stella", Type = "Cat"},
        new Pet{Id = 4, Name = "Buddy", Type = "Dog"},
        new Pet{Id = 5, Name = "Birdy", Type = "Bird"}
    ];
    [HttpGet]//Annotation for Get from the route annotation
    public IActionResult GetAllPets()
    {
        //Return IAction result to send HTTP status code
        return Ok(petList);
    }

    [HttpPost]//Adds an object to our storage
    public IActionResult CreatePet(Pet p)
    {
        petList.Add(p);
        return Ok(petList);
    }

    [HttpDelete]//Remove an object or item from our list
    public IActionResult DeletePet(string name)
    {
        var findPet = petList.FirstOrDefault(p => p.Name == name);
        
        if(findPet is null)return NotFound();

        petList.Remove(findPet);
        return Ok(petList);
    }

    //[HttpDelete]
    //public IActionResult DeletePet(int id)
    //{
    //    
    //}

}