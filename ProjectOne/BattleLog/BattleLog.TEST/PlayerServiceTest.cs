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
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        List<Player> playerList = [
            new Player{Id = 1, Name = "Bob", AttackPower = 1, Experience = 1, Health = 5},
            new Player{Id = 2, Name = "Bill", AttackPower = 2, Experience = 1, Health = 5},
            new Player{Id = 3, Name = "Tim", AttackPower = 4, Experience = 1, Health = 5},
        ];

        Player newPlayer = new Player{Id = 0, Name = "Frank", AttackPower = 1, Experience = 0, Health = 5};

        mockRepo.Setup(repo => repo.CreateNewPlayer(It.IsAny<Player>()))
            .Callback(() => playerList.Add(newPlayer))
            .Returns(newPlayer);
        
        PlayerInDTO playerInDTO = new PlayerInDTO{Name = newPlayer.Name, AttackPower = newPlayer.AttackPower, Health = newPlayer.Health};
        //Act
        Player myPlayer = playerService.CreateNewPlayer(playerInDTO);

        //Assert
        Assert.True(Object.ReferenceEquals(myPlayer, newPlayer));
        Assert.Contains(myPlayer, playerList);
        mockRepo.Verify(x => x.CreateNewPlayer(It.IsAny<Player>()), Times.Once());
    }
}
