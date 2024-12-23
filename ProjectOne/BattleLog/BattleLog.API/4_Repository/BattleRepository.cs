using BattleLog.API.Data;
using BattleLog.API.Model;

namespace BattleLog.API.Repository;

public class BattleRepository : IBattleRepository
{
    //Need the DB Object to work with.
    private readonly DataContext _battleContext;

    public BattleRepository(DataContext battleContext) => _battleContext = battleContext;

    public Battle CreateNewBattle(Battle newBattle)
    {
        //Insert into Battles Values (newBattle)
        _battleContext.Battles.Add(newBattle);
        _battleContext.SaveChanges();
        return newBattle;
    }

    public IEnumerable<Battle> GetAllBattles()
    {
        return _battleContext.Battles.ToList();
    }


    public Battle? GetBattleById(int id)
    {
        return _battleContext.Battles.FirstOrDefault(p => p.Id == id);
    }

    public Battle? UpdateBattleById(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteBattleById(int id)
    {
        var battle = GetBattleById(id);
        _battleContext.Battles.Remove(battle!);
        _battleContext.SaveChanges();
    }
}