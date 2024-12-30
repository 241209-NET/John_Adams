using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;

namespace BattleLog.API.Service;

public class EnemyService : IEnemyService
{
    private readonly IEnemyRepository _enemyRepository;
    private readonly IMapper _mapper;

    public EnemyService(IEnemyRepository enemyRepository, IMapper mapper)
    {
        _enemyRepository = enemyRepository;
        _mapper = mapper;
    }

    public Enemy CreateNewEnemy(EnemyInDTO newEnemy)
    {
        Enemy enemy = _mapper.Map<Enemy>(newEnemy);
        return _enemyRepository.CreateNewEnemy(enemy);
    }

    public IEnumerable<Enemy> GetAllEnemies()
    {
        return _enemyRepository.GetAllEnemies();
    }

    public Enemy? GetEnemyById(int id)
    {
        if(id < 1) return null;
        return _enemyRepository.GetEnemyById(id);
    }
    
    public Enemy? UpdateEnemy(Enemy enemy)
    {
        var e = GetEnemyById(enemy.Id);
        if(e is null) return null;

        e.AttackPower = enemy.AttackPower;
        e.Health = enemy.Health;
        e.Name = enemy.Name;
        e.Experience = enemy.Experience;
        
        _enemyRepository.UpdateEnemy(e);
        return e;
    }

    public Enemy? DeleteEnemyById(int id)
    {
        var enemy = GetEnemyById(id);
        if(enemy is not null) _enemyRepository.DeleteEnemyById(id);
        return enemy;

    }

}