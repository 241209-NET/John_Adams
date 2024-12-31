using AutoMapper;
using BattleLog.API.DTO;

namespace BattleLog.API.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Player, PlayerInDTO>().ReverseMap();
        CreateMap<Player, PlayerOutDTO>().ReverseMap();
        CreateMap<Enemy, EnemyInDTO>().ReverseMap();
        CreateMap<Enemy, EnemyOutDTO>().ReverseMap();
        CreateMap<Battle, BattleInDTO>().ReverseMap();
        CreateMap<Battle, BattleOutDTO>().ReverseMap();
    }
}