using Microsoft.AspNetCore.Mvc;

namespace BattleLog.API.Controller;

[Route("/")]
[ApiController]
public class HomeController : ControllerBase
{    
    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok("Hello World");
    }
}