using BattleLog.API.Model;
using BattleLog.API.Repository;

namespace BattleLog.API.Service;

public class BattleService : IBattleService
{
    private readonly IBattleRepository _battleRepository;

    public BattleService(IBattleRepository battleRepository) => _battleRepository = battleRepository;

    public Battle CreateNewBattle(Battle newBattle)
    {
        return _battleRepository.CreateNewBattle(newBattle);
    }

    public IEnumerable<Battle> GetAllBattles()
    {
        return _battleRepository.GetAllBattles();
    }

    public Battle? GetBattleById(int id)
    {
        if(id < 1) return null;
        return _battleRepository.GetBattleById(id);
    }
    
    public Battle? UpdateBattleById(int id)
    {
        throw new NotImplementedException();
    }

    public Battle? DeleteBattleById(int id)
    {
        var battle = GetBattleById(id);
        if(battle is not null) _battleRepository.DeleteBattleById(id);
        return battle;

    }

}