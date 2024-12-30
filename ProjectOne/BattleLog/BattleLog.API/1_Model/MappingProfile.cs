using AutoMapper;
using BattleLog.API.DTO;

namespace BattleLog.API.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Player, PlayerInDTO>();
        CreateMap<Player, PlayerOutDTO>();
        CreateMap<Enemy, EnemyInDTO>();
        CreateMap<Enemy, EnemyOutDTO>();
        CreateMap<Battle, BattleInDTO>();
        CreateMap<Battle, BattleOutDTO>();
    }
}