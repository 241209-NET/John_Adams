using BattleLog.API.Model;

namespace BattleLog.API.Service;

public interface IPlayerService
{
    Player CreateNewPlayer(Player newPlayer);
    IEnumerable<Player> GetAllPlayers();
    Player? GetPlayerById(int id);
    Player? UpdatePlayerById(int id);
    Player? DeletePlayerById(int id);
}

public interface IEnemyService
{
    Enemy CreateNewEnemy(Enemy newEnemy);
    IEnumerable<Enemy> GetAllEnemies();
    Enemy? GetEnemyById(int id);
    Enemy? UpdateEnemyById(int id);
    Enemy? DeleteEnemyById(int id);
}