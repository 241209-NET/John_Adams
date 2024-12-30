using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;

namespace BattleLog.API.Service;

public class BattleService : IBattleService
{
    private readonly IBattleRepository _battleRepository;
    private readonly IMapper _mapper;

    public BattleService(IBattleRepository battleRepository, IMapper mapper) 
    {
        _battleRepository = battleRepository;
        _mapper = mapper;
    }

    public Battle CreateNewBattle(BattleInDTO newBattle)
    {
        Battle b = _mapper.Map<Battle>(newBattle);
        return _battleRepository.CreateNewBattle(b);
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
    
    public Battle? UpdateBattle(Battle battle)
    {
        var b = GetBattleById(battle.Id);
        if(b is null) return null;

        b.player = battle.player;
        b.enemy = battle.enemy;
        b.BattleDate = battle.BattleDate;
        
        _battleRepository.UpdateBattle(b);
        return b;
    }

    public Battle? DeleteBattleById(int id)
    {
        var battle = GetBattleById(id);
        if(battle is not null) _battleRepository.DeleteBattleById(id);
        return battle;
    }

}