using BattleLog.API.DTO;
using BattleLog.API.Model;

namespace BattleLog.API.Service;

public interface IPlayerService
{
    Player CreateNewPlayer(PlayerInDTO newPlayer);
    IEnumerable<Player> GetAllPlayers();
    Player? GetPlayerById(int id);
    Player? UpdatePlayer(Player p);
    Player? DeletePlayerById(int id);
}

public interface IEnemyService
{
    Enemy CreateNewEnemy(EnemyInDTO newEnemy);
    IEnumerable<Enemy> GetAllEnemies();
    Enemy? GetEnemyById(int id);
    Enemy? UpdateEnemy(Enemy enemy);
    Enemy? DeleteEnemyById(int id);
}

public interface IBattleService
{
    Battle CreateNewBattle(BattleInDTO newEnemy);
    IEnumerable<Battle> GetAllBattles();
    Battle? GetBattleById(int id);
    Battle? UpdateBattle(Battle battle);
    Battle? DeleteBattleById(int id);
}