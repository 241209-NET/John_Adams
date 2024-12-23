using BattleLog.API.Model;
using BattleLog.API.Repository;

namespace BattleLog.API.Service;

public class EnemyService : IEnemyService
{
    private readonly IEnemyRepository _enemyRepository;

    public EnemyService(IEnemyRepository enemyRepository) => _enemyRepository = enemyRepository;

    public Enemy CreateNewEnemy(Enemy newEnemy)
    {
        return _enemyRepository.CreateNewEnemy(newEnemy);
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
    
    public Enemy? UpdateEnemyById(int id)
    {
        throw new NotImplementedException();
    }

    public Enemy? DeleteEnemyById(int id)
    {
        var enemy = GetEnemyById(id);
        if(enemy is not null) _enemyRepository.DeleteEnemyById(id);
        return enemy;

    }

}