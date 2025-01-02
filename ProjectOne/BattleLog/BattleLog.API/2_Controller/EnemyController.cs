using Microsoft.AspNetCore.Mvc;
using BattleLog.API.Service;
using BattleLog.API.Model;
using BattleLog.API.DTO;

namespace BattleLog.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class EnemyController : ControllerBase
{
    private readonly IEnemyService _enemyService;

    public EnemyController(IEnemyService enemyService) => _enemyService = enemyService;

    [HttpPost]
    public IActionResult CreateNewEnemy(EnemyInDTO newEnemy)
    {
        var enemy = _enemyService.CreateNewEnemy(newEnemy);
        return Ok(enemy);
    }

    [HttpGet]
    public IActionResult GetAllEnemies()
    {
        var enemyList = _enemyService.GetAllEnemies();        
        return Ok(enemyList);
    }

    [HttpGet("{id}")]
    public IActionResult GetEnemyById(int id)
    {
        var findEnemy = _enemyService.GetEnemyById(id);

        if(findEnemy is null) return NotFound();
        
        return Ok(findEnemy);
    }

    [HttpPut]
    public IActionResult UpdateEnemy([FromBody]Enemy enemy)
    {
        var e = _enemyService.UpdateEnemy(enemy);
        return Ok(enemy);
    }

    [HttpDelete]
    public IActionResult DeleteEnemy(int id)
    {
        var deleteEnemy = _enemyService.DeleteEnemyById(id);

        if(deleteEnemy is null) return NotFound();

        return Ok(deleteEnemy);
    }
}