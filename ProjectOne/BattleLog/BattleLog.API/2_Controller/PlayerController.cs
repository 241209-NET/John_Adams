using Microsoft.AspNetCore.Mvc;
using BattleLog.API.Service;
using BattleLog.API.Model;

namespace BattleLog.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService) => _playerService = playerService;

    [HttpPost]
    public IActionResult CreateNewPlayer(Player newPlayer)
    {
        var Player = _playerService.CreateNewPlayer(newPlayer);
        return Ok(Player);
    }

    [HttpGet]
    public IActionResult GetAllPlayers()
    {
        var playerList = _playerService.GetAllPlayers();        
        return Ok(playerList);
    }

    [HttpGet("{id}")]
    public IActionResult GetPlayerById(int id)
    {
        var findPlayer = _playerService.GetPlayerById(id);

        if(findPlayer is null) return NotFound();
        
        return Ok(findPlayer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePlayerById(int id)
    {
        var Player = _playerService.UpdatePlayerById(id);
        return Ok(Player);
    }

    [HttpDelete]
    public IActionResult DeletePlayer(int id)
    {
        var deletePlayer = _playerService.DeletePlayerById(id);

        if(deletePlayer is null) return NotFound();

        return Ok(deletePlayer);
    }
}