using System.Data.Common;
using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;
using BattleLog.API.Service;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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

    [Fact]
    public void GetAllPlayerTest()
    {
        Mock<IPlayerRepository> mockRepo = new();
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

        mockRepo.Setup(repo => repo.GetAllPlayers()).Returns(playerList);

        //Act
        var result = playerService.GetAllPlayers().ToList();

        //Assert
        Assert.Equal(playerList, result);
    }

    [Fact]
    public void TestGetPlayerById()
    {
        // Arrange
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Player player = new Player { Id = 1, Name = "Bob", AttackPower = 1, Experience = 1, Health = 5 };

        mockRepo.Setup(repo => repo.GetPlayerById(It.IsAny<int>())).Returns(player);

        // Act
        var result = playerService.GetPlayerById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(player, result);
        mockRepo.Verify(x => x.GetPlayerById(It.IsAny<int>()), Times.Once());
    }

    [Fact]
    public void TestUpdatePlayer()
    {
        // Arrange
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Player existingPlayer = new Player { Id = 1, Name = "Bob", AttackPower = 1, Experience = 1, Health = 5 };
        Player updatedPlayer = new Player { Id = 1, Name = "Bob Updated", AttackPower = 2, Experience = 2, Health = 10 };

        mockRepo.Setup(repo => repo.GetPlayerById(It.IsAny<int>())).Returns(existingPlayer);
        mockRepo.Setup(repo => repo.UpdatePlayer(It.IsAny<Player>()));

        // Act
        var result = playerService.UpdatePlayer(updatedPlayer);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedPlayer.Name, result.Name);
        Assert.Equal(updatedPlayer.AttackPower, result.AttackPower);
        Assert.Equal(updatedPlayer.Experience, result.Experience);
        Assert.Equal(updatedPlayer.Health, result.Health);
        mockRepo.Verify(x => x.GetPlayerById(It.IsAny<int>()), Times.Once());
        mockRepo.Verify(x => x.UpdatePlayer(It.IsAny<Player>()), Times.Once());
    }

    [Fact]
    public void TestDeletePlayerById()
    {
        // Arrange
        Mock<IPlayerRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        PlayerService playerService = new(mockRepo.Object, mapper);

        Player player = new Player { Id = 1, Name = "Bob", AttackPower = 1, Experience = 1, Health = 5 };

        mockRepo.Setup(repo => repo.GetPlayerById(It.IsAny<int>())).Returns(player);
        mockRepo.Setup(repo => repo.DeletePlayerById(It.IsAny<int>()));

        // Act
        var result = playerService.DeletePlayerById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(player, result);
        mockRepo.Verify(x => x.GetPlayerById(It.IsAny<int>()), Times.Once());
        mockRepo.Verify(x => x.DeletePlayerById(It.IsAny<int>()), Times.Once());
    }
}
