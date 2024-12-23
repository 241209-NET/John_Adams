namespace BattleLog.API.Model;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Experience { get; set; }
}