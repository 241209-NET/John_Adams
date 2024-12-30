using BattleLog.API.Model;

namespace BattleLog.API.Repository;

public interface IPlayerRepository
{
    //CRUD
    Player CreateNewPlayer(Player newPlayer); 
    IEnumerable<Player> GetAllPlayers(); 
    Player? GetPlayerById(int id); 
    Player? UpdatePlayer(Player p);
    void DeletePlayerById(int id);    
}

public interface IEnemyRepository
{
    //CRUD
    Enemy CreateNewEnemy(Enemy newPlayer); 
    IEnumerable<Enemy> GetAllEnemies(); 
    Enemy? GetEnemyById(int id); 
    Enemy? UpdateEnemy(Enemy enemy);
    void DeleteEnemyById(int id);    
}

public interface IBattleRepository
{
    //CRUD
    Battle CreateNewBattle(Battle newPlayer); 
    IEnumerable<Battle> GetAllBattles(); 
    Battle? GetBattleById(int id); 
    Battle? UpdateBattle(Battle battle);
    void DeleteBattleById(int id);    
}