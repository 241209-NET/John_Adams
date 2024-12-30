using System.Data.Common;
using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;
using BattleLog.API.Service;
using Moq;

namespace BattleLog.TEST;

public class PlayerServiceTest
{
    [Fact]
    public void TestCreateNewPlayer()
    {
        //Arrange
        Mock<IPlayerRepository> mockRepo = new();
        // Configure AutoMapper
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>(); // Use your actual mapping profile class
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        List<Player> playerList = [
            new Player{Id = 1, Name = "Bob", AttackPower = 1, Experience = 1, Health = 5},
            new Player{Id = 2, Name = "Bill", AttackPower = 2, Experience = 1, Health = 5},
            new Player{Id = 3, Name = "Tim", AttackPower = 4, Experience = 1, Health = 5},
            new Player{Id = 4, Name = "Jim", AttackPower = 8, Experience = 1, Health = 5},
            new Player{Id = 5, Name = "Man", AttackPower = 16, Experience = 1, Health = 5}
        ];

        Player newPlayer = new Player{Id = 1, Name = "Frank", AttackPower = 1, Experience = 0, Health = 5};

        mockRepo.Setup(repo => repo.CreateNewPlayer(It.IsAny<Player>()))
            .Callback((Player p) => playerList.Add(p))
            .Returns(newPlayer);
        
        PlayerInDTO playerInDTO = new PlayerInDTO{Name = newPlayer.Name, AttackPower = newPlayer.AttackPower, Health = newPlayer.Health};
        //Act
        var myPlayer = playerService.CreateNewPlayer(playerInDTO);

        //Assert
        Assert.Contains(newPlayer, playerList);
        mockRepo.Verify(x => x.CreateNewPlayer(It.IsAny<Player>()), Times.Once());
    }
}
