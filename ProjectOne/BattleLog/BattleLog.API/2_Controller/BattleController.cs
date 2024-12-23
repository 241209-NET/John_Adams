using Microsoft.AspNetCore.Mvc;
using BattleLog.API.Service;
using BattleLog.API.Model;

namespace BattleLog.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class BattleController : ControllerBase
{
    private readonly IBattleService _battleService;

    public BattleController(IBattleService battleService) => _battleService = battleService;

    [HttpPost]
    public IActionResult CreateNewBattle(Battle newBattle)
    {
        var battle = _battleService.CreateNewBattle(newBattle);
        return Ok(battle);
    }

    [HttpGet]
    public IActionResult GetAllBattles()
    {
        var battleList = _battleService.GetAllBattles();        
        return Ok(battleList);
    }

    [HttpGet("{id}")]
    public IActionResult GetBattleById(int id)
    {
        var findBattle = _battleService.GetBattleById(id);

        if(findBattle is null) return NotFound();
        
        return Ok(findBattle);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBattleById(int id)
    {
        var battle = _battleService.UpdateBattleById(id);
        return Ok(battle);
    }

    [HttpDelete]
    public IActionResult DeleteBattle(int id)
    {
        var deleteBattle = _battleService.DeleteBattleById(id);

        if(deleteBattle is null) return NotFound();

        return Ok(deleteBattle);
    }
}