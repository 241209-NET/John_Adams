using Microsoft.AspNetCore.Mvc;
using BattleLog.API.Service;
using BattleLog.API.Model;
using BattleLog.API.DTO;

namespace BattleLog.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class BattleController : ControllerBase
{
    private readonly IBattleService _battleService;

    public BattleController(IBattleService battleService) => _battleService = battleService;

    [HttpPost]
    public IActionResult CreateNewBattle(BattleInDTO newBattle)
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

    [HttpPut]
    public IActionResult UpdateBattle([FromBody]Battle battle)
    {
        var b = _battleService.UpdateBattle(battle);
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