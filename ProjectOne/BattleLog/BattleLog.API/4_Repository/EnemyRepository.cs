using BattleLog.API.Data;
using BattleLog.API.Model;

namespace BattleLog.API.Repository;

public class EnemyRepository : IEnemyRepository
{
    //Need the DB Object to work with.
    private readonly DataContext _enemyContext;

    public EnemyRepository(DataContext enemyContext) => _enemyContext = enemyContext;

    public Enemy CreateNewEnemy(Enemy newEnemy)
    {
        //Insert into Enemies Values (newEnemy)
        _enemyContext.Enemies.Add(newEnemy);
        _enemyContext.SaveChanges();
        return newEnemy;
    }

    public IEnumerable<Enemy> GetAllEnemies()
    {
        return _enemyContext.Enemies.ToList();
    }


    public Enemy? GetEnemyById(int id)
    {
        return _enemyContext.Enemies.FirstOrDefault(p => p.Id == id);
    }

    public Enemy? UpdateEnemy(Enemy e)
    {
        _enemyContext.Enemies.Update(e);
        _enemyContext.SaveChanges();
        return e;
    }

    public void DeleteEnemyById(int id)
    {
        var Enemy = GetEnemyById(id);
        _enemyContext.Enemies.Remove(Enemy!);
        _enemyContext.SaveChanges();
    }
}