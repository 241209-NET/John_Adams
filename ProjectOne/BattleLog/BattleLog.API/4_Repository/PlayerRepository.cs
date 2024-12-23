using BattleLog.API.Data;
using BattleLog.API.Model;

namespace BattleLog.API.Repository;

public class PlayerRepository : IPlayerRepository
{
    //Need the DB Object to work with.
    private readonly DataContext _playerContext;

    public PlayerRepository(DataContext playerContext) => _playerContext = playerContext;

    public Player CreateNewPlayer(Player newPlayer)
    {
        //Insert into Players Values (newPlayer)
        _playerContext.Players.Add(newPlayer);
        _playerContext.SaveChanges();
        return newPlayer;
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _playerContext.Players.ToList();
    }


    public Player? GetPlayerById(int id)
    {
        return _playerContext.Players.FirstOrDefault(p => p.Id == id);
    }

    public Player? UpdatePlayerById(int id)
    {
        throw new NotImplementedException();
    }

    public void DeletePlayerById(int id)
    {
        var player = GetPlayerById(id);
        _playerContext.Players.Remove(player!);
        _playerContext.SaveChanges();
    }
}