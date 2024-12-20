using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PetTracker.API.Model;
using PetTracker.API.Service;

namespace PetTracker.API.Controller;
//Input and output only not business logic should not care if variables are useable
[Route("api/[controller]")]//Annotation for route of the controller
[ApiController]//Annotation for API Controller for ASPNET
public class PetController : ControllerBase
{
    private readonly IPetService _petService;

    public PetController(IPetService petService) => _petService = petService;

    [HttpGet]//Annotation for Get from the route annotation
    public IActionResult GetAllPets()
    {
        var petList = _petService.GetAllPets();
        //Return IAction result to send HTTP status code
        return Ok(petList);
    }

    [HttpPost]//Adds an object to our storage
    public IActionResult CreatePet(Pet p)
    {
        var pet = _petService.CreatePet(p);
        return Ok(pet);
    }

    [HttpDelete]//Remove an object or item from our list
    public IActionResult DeletePet(string name)
    {
        throw new NotImplementedException();
    }

    //[HttpDelete]
    //public IActionResult DeletePet(int id)
    //{
    //    
    //}

}