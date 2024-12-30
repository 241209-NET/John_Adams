using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;

namespace BattleLog.API.Service;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    public PlayerService(IPlayerRepository playerRepository, IMapper mapper) 
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public Player CreateNewPlayer(PlayerInDTO newPlayer)
    {
        Player player = _mapper.Map<Player>(newPlayer);
        return _playerRepository.CreateNewPlayer(player);
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
    
    public Player? UpdatePlayer(Player p)
    {
        var player = GetPlayerById(p.Id);
        if(player is null) return null;

        player.AttackPower = p.AttackPower;
        player.Health = p.Health;
        player.Name = p.Name;
        player.Experience = p.Experience;
        
        _playerRepository.UpdatePlayer(player);
        return player;
    }

    public Player? DeletePlayerById(int id)
    {
        var player = GetPlayerById(id);
        if(player is not null) _playerRepository.DeletePlayerById(id);
        return player;

    }

}