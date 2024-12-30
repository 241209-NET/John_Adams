
using BattleLog.API.Model;

namespace BattleLog.API.DTO;

public class BattleInDTO
{
    public required Player Player { get; set; }
    public required Enemy enemy { get; set; }
    public DateOnly? BattleDate { get; set; }
}

public class BattleOutDTO
{
    public int Id { get; set; }
    public required Player player { get; set; }
    public required Enemy enemy { get; set; }
    public DateOnly? BattleDate { get; set; }
}

public class EnemyInDTO
{
    public required string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
}

public class EnemyOutDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
}

public class PlayerInDTO
{
    public required string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
}

public class PlayerOutDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Experience { get; set; }
}