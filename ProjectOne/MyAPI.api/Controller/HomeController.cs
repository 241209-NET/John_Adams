using Microsoft.AspNetCore.Mvc;

namespace PetTracker.API.Controller;

[Route("/")]//Annotation for route of the controller
[ApiController]//Annotation for API Controller for ASPNET
public class HomeController : ControllerBase
{
    [HttpGet]//Annotation for Get from the route annotation
    public IActionResult Welcome()
    {
        //Return IAction result to send HTTP status code
        return Ok("Hello World!");
    }

}