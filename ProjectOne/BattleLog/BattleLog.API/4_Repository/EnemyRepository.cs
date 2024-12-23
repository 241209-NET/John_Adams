using BattleLog.API.Data;
using BattleLog.API.Model;

namespace BattleLog.API.Repository;

public class EnemyRepository : IEnemyRepository
{
    //Need the DB Object to work with.
    private readonly DataContext _EnemyContext;

    public EnemyRepository(DataContext EnemyContext) => _EnemyContext = EnemyContext;

    public Enemy CreateNewEnemy(Enemy newEnemy)
    {
        //Insert into Enemys Values (newEnemy)
        _EnemyContext.Enemies.Add(newEnemy);
        _EnemyContext.SaveChanges();
        return newEnemy;
    }

    public IEnumerable<Enemy> GetAllEnemies()
    {
        return _EnemyContext.Enemies.ToList();
    }


    public Enemy? GetEnemyById(int id)
    {
        return _EnemyContext.Enemies.FirstOrDefault(p => p.Id == id);
    }

    public Enemy? UpdateEnemyById(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteEnemyById(int id)
    {
        var Enemy = GetEnemyById(id);
        _EnemyContext.Enemies.Remove(Enemy!);
        _EnemyContext.SaveChanges();
    }
}