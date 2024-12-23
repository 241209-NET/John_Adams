using BattleLog.API.Model;

namespace BattleLog.API.Repository;

public interface IPlayerRepository
{
    //CRUD
    Player CreateNewPlayer(Player newPlayer); 
    IEnumerable<Player> GetAllPlayers(); 
    Player? GetPlayerById(int id); 
    Player? UpdatePlayerById(int id);
    void DeletePlayerById(int id);    
}

public interface IEnemyRepository
{
    //CRUD
    Enemy CreateNewEnemy(Enemy newPlayer); 
    IEnumerable<Enemy> GetAllEnemies(); 
    Enemy? GetEnemyById(int id); 
    Enemy? UpdateEnemyById(int id);
    void DeleteEnemyById(int id);    
}