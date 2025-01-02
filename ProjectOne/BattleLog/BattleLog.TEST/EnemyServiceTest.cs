
using AutoMapper;
using BattleLog.API.DTO;
using BattleLog.API.Model;
using BattleLog.API.Repository;
using BattleLog.API.Service;
using Moq;

namespace BattleLog.TEST;

public class EnemyServiceTest
{
    [Fact]
    public void TestCreateNewEnemy()
    {
        //Arrange
        Mock<IEnemyRepository> mockRepo = new();
        //Configure AutoMapper
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        List<Enemy> enemyList = [
            new Enemy{Id = 1, Name = "Blob", AttackPower = 1, Experience = 1, Health = 5},
            new Enemy{Id = 2, Name = "slime", AttackPower = 2, Experience = 1, Health = 10},
            new Enemy{Id = 3, Name = "Goblin", AttackPower = 2, Experience = 1, Health = 7}
        ];

        Enemy newEnemy = new Enemy{Id = 1, Name = "Orc", AttackPower = 4, Experience = 1, Health = 15};

        mockRepo.Setup(repo => repo.CreateNewEnemy(It.IsAny<Enemy>()))
            .Callback(() => enemyList.Add(newEnemy))
            .Returns(newEnemy);
        
        EnemyInDTO enemyInDTO = new EnemyInDTO{Name = newEnemy.Name, AttackPower = newEnemy.AttackPower, Health = newEnemy.Health};
        //Act
        Enemy myEnemy = enemyService.CreateNewEnemy(enemyInDTO);

        Assert.True(Object.ReferenceEquals(myEnemy, newEnemy));
        Assert.Contains(myEnemy, enemyList);
        mockRepo.Verify(x => x.CreateNewEnemy(It.IsAny<Enemy>()), Times.Once());
    }
    [Fact]
    public void TestGetAllEnemies()
    {
        // Arrange
        Mock<IEnemyRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        List<Enemy> enemyList = [
            new Enemy{Id = 1, Name = "Blob", AttackPower = 1, Experience = 1, Health = 5},
            new Enemy{Id = 2, Name = "slime", AttackPower = 2, Experience = 1, Health = 10},
            new Enemy{Id = 3, Name = "Goblin", AttackPower = 2, Experience = 1, Health = 7}
        ];

        mockRepo.Setup(repo => repo.GetAllEnemies()).Returns(enemyList);

        // Act
        var result = enemyService.GetAllEnemies().ToList();

        // Assert
        Assert.Equal(enemyList, result);
    }

    [Fact]
    public void TestGetEnemyById()
    {
        // Arrange
        Mock<IEnemyRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        Enemy enemy = new Enemy { Id = 1, Name = "Blob", AttackPower = 1, Experience = 1, Health = 5 };

        mockRepo.Setup(repo => repo.GetEnemyById(It.IsAny<int>())).Returns(enemy);

        // Act
        var result = enemyService.GetEnemyById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(enemy, result);
        mockRepo.Verify(x => x.GetEnemyById(It.IsAny<int>()), Times.Once());
    }

    [Fact]
    public void TestUpdateEnemy()
    {
        // Arrange
        Mock<IEnemyRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        Enemy existingEnemy = new Enemy { Id = 1, Name = "Blob", AttackPower = 1, Experience = 1, Health = 5 };
        Enemy updatedEnemy = new Enemy { Id = 1, Name = "Blob Updated", AttackPower = 3, Experience = 2, Health = 10 };

        mockRepo.Setup(repo => repo.GetEnemyById(It.IsAny<int>())).Returns(existingEnemy);
        mockRepo.Setup(repo => repo.UpdateEnemy(It.IsAny<Enemy>()));

        // Act
        var result = enemyService.UpdateEnemy(updatedEnemy);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedEnemy.Name, result.Name);
        Assert.Equal(updatedEnemy.AttackPower, result.AttackPower);
        Assert.Equal(updatedEnemy.Experience, result.Experience);
        Assert.Equal(updatedEnemy.Health, result.Health);
        mockRepo.Verify(x => x.GetEnemyById(It.IsAny<int>()), Times.Once());
        mockRepo.Verify(x => x.UpdateEnemy(It.IsAny<Enemy>()), Times.Once());
    }

    [Fact]
    public void TestDeleteEnemyById()
    {
        // Arrange
        Mock<IEnemyRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        Enemy enemy = new Enemy { Id = 1, Name = "Blob", AttackPower = 1, Experience = 1, Health = 5 };

        mockRepo.Setup(repo => repo.GetEnemyById(It.IsAny<int>())).Returns(enemy);
        mockRepo.Setup(repo => repo.DeleteEnemyById(It.IsAny<int>()));

        // Act
        var result = enemyService.DeleteEnemyById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(enemy, result);
        mockRepo.Verify(x => x.GetEnemyById(It.IsAny<int>()), Times.Once());
        mockRepo.Verify(x => x.DeleteEnemyById(It.IsAny<int>()), Times.Once());
    }
    [Fact]
    public void TestGetEnemyById_ReturnsNullIfIdIsLessThanOne()
    {
        // Arrange
        Mock<IEnemyRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg => 
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        // Act
        var result = enemyService.GetEnemyById(0);

        // Assert
        Assert.Null(result);
        mockRepo.Verify(x => x.GetEnemyById(It.IsAny<int>()), Times.Never());
    }

    [Fact]
    public void TestUpdateEnemy_ReturnsNullIfEnemyDoesNotExist()
    {
        // Arrange
        Mock<IEnemyRepository> mockRepo = new();
        var config = new MapperConfiguration(cfg => 
        {
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        EnemyService enemyService = new(mockRepo.Object, mapper);

        mockRepo.Setup(repo => repo.GetEnemyById(It.IsAny<int>())).Returns((Enemy)null!);

        Enemy enemyToUpdate = new() { Id = 99, Name = "Orc", AttackPower = 10, Experience = 5, Health = 50 };

        // Act
        var result = enemyService.UpdateEnemy(enemyToUpdate);

        // Assert
        Assert.Null(result);
        mockRepo.Verify(x => x.GetEnemyById(It.IsAny<int>()), Times.Once());
        mockRepo.Verify(x => x.UpdateEnemy(It.IsAny<Enemy>()), Times.Never());
    }
}