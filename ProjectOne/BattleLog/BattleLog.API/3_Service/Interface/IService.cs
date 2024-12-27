using BattleLog.API.Model;

namespace BattleLog.API.Service;

public interface IPlayerService
{
    Player CreateNewPlayer(Player newPlayer);
    IEnumerable<Player> GetAllPlayers();
    Player? GetPlayerById(int id);
    Player? UpdatePlayer(Player p);
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

public interface IBattleService
{
    Battle CreateNewBattle(Battle newEnemy);
    IEnumerable<Battle> GetAllBattles();
    Battle? GetBattleById(int id);
    Battle? UpdateBattleById(int id);
    Battle? DeleteBattleById(int id);
}