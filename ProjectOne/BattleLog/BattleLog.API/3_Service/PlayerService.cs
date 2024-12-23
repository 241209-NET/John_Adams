using BattleLog.API.Model;
using BattleLog.API.Repository;

namespace BattleLog.API.Service;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository) => _playerRepository = playerRepository;

    public Player CreateNewPlayer(Player newPlayer)
    {
        return _playerRepository.CreateNewPlayer(newPlayer);
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _playerRepository.GetAllPlayers();
    }

    public Player? GetPlayerById(int id)
    {
        if(id < 1) return null;
        return _playerRepository.GetPlayerById(id);
    }
    
    public Player? UpdatePlayerById(int id)
    {
        throw new NotImplementedException();
    }

    public Player? DeletePlayerById(int id)
    {
        var player = GetPlayerById(id);
        if(player is not null) _playerRepository.DeletePlayerById(id);
        return player;

    }

}