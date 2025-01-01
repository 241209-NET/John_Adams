
using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;
using BattleLog.API.Service;
using Moq;

namespace BattleLog.TEST;

public class BattleLogServiceTest
{
    [Fact]
    public void TestCreateNewBattle()
    {
        // Arrange
        Mock<IBattleRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        BattleService battleService = new(mockRepo.Object, mapper);
        Player newPlayer = new Player{Id = 0, Name = "Frank", AttackPower = 1, Experience = 0, Health = 5};
        Enemy newEnemy = new Enemy{Id = 1, Name = "Orc", AttackPower = 4, Experience = 1, Health = 15};

        List<Battle> battleList = new()
        {
            new Battle { Id = 1, player = newPlayer, enemy = newEnemy, BattleDate = DateOnly.FromDateTime(DateTime.Now) }
        };

        Battle newBattle = new() { Id = 2, player = null, enemy = null, BattleDate = DateOnly.FromDateTime(DateTime.Now) };

        mockRepo.Setup(repo => repo.CreateNewBattle(It.IsAny<Battle>()))
            .Callback(() => battleList.Add(newBattle))
            .Returns(newBattle);

        BattleInDTO battleInDTO = new BattleInDTO{Player = newPlayer, enemy = newEnemy, BattleDate = newBattle.BattleDate };

        // Act
        Battle myBattle = battleService.CreateNewBattle(battleInDTO);

        // Assert
        Assert.True(ReferenceEquals(myBattle, newBattle));
        Assert.Contains(myBattle, battleList);
        mockRepo.Verify(x => x.CreateNewBattle(It.IsAny<Battle>()), Times.Once());
    }

    [Fact]
    public void TestGetAllBattles()
    {
        // Arrange
        Mock<IBattleRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        BattleService battleService = new(mockRepo.Object, mapper);

        List<Battle> battleList = new()
        {
            new Battle { Id = 1, player = null, enemy = null, BattleDate = DateOnly.FromDateTime(DateTime.Now) },
            new Battle { Id = 2, player = null, enemy = null, BattleDate = DateOnly.FromDateTime(DateTime.Now) }
        };

        mockRepo.Setup(repo => repo.GetAllBattles()).Returns(battleList);

        // Act
        var result = battleService.GetAllBattles().ToList();

        // Assert
        Assert.Equal(battleList, result);
    }

    [Fact]
    public void TestGetBattleById()
    {
        // Arrange
        Mock<IBattleRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        BattleService battleService = new(mockRepo.Object, mapper);

        Battle battle = new() { Id = 1, player = null, enemy = null, BattleDate = DateOnly.FromDateTime(DateTime.Now) };

        mockRepo.Setup(repo => repo.GetBattleById(1)).Returns(battle);

        // Act
        var result = battleService.GetBattleById(1);

        // Assert
        Assert.Equal(battle, result);
    }

    [Fact]
    public void TestUpdateBattle()
    {
        // Arrange
        Mock<IBattleRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        BattleService battleService = new(mockRepo.Object, mapper);
        Player newPlayer = new Player{Id = 0, Name = "Frank", AttackPower = 1, Experience = 0, Health = 5};
        Enemy newEnemy = new Enemy{Id = 1, Name = "Orc", AttackPower = 4, Experience = 1, Health = 15};

        Battle existingBattle = new() { Id = 1, player = null, enemy = null, BattleDate = DateOnly.FromDateTime(DateTime.Now) };
        Battle updatedBattle = new() { Id = 1, player = newPlayer, enemy = newEnemy, BattleDate = DateOnly.FromDateTime(DateTime.Now) };

        mockRepo.Setup(repo => repo.GetBattleById(1)).Returns(existingBattle);
        mockRepo.Setup(repo => repo.UpdateBattle(It.IsAny<Battle>())).Callback(() =>
        {
            existingBattle.player = updatedBattle.player;
            existingBattle.enemy = updatedBattle.enemy;
            existingBattle.BattleDate = updatedBattle.BattleDate;
        });

        // Act
        var result = battleService.UpdateBattle(updatedBattle);

        // Assert
        Assert.Equal(updatedBattle.player, result?.player);
        Assert.Equal(updatedBattle.enemy, result?.enemy);
        Assert.Equal(updatedBattle.BattleDate, result?.BattleDate);
        mockRepo.Verify(x => x.UpdateBattle(It.IsAny<Battle>()), Times.Once());
    }

    [Fact]
    public void TestDeleteBattleById()
    {
        // Arrange
        Mock<IBattleRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        BattleService battleService = new(mockRepo.Object, mapper);

        Battle battle = new() { Id = 1, player = null, enemy = null, BattleDate = DateOnly.FromDateTime(DateTime.Now) };

        mockRepo.Setup(repo => repo.GetBattleById(1)).Returns(battle);
        mockRepo.Setup(repo => repo.DeleteBattleById(1));

        // Act
        var result = battleService.DeleteBattleById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(battle, result);
        mockRepo.Verify(x => x.DeleteBattleById(1), Times.Once());
        mockRepo.Verify(x => x.GetBattleById(It.IsAny<int>()), Times.Once());
        mockRepo.Verify(x => x.DeleteBattleById(It.IsAny<int>()), Times.Once());
    }
}