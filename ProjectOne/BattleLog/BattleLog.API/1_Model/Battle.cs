namespace BattleLog.API.Model;

public class Battle
{
    public int Id { get; set; }
    public Player player { get; set; }
    public Enemy enemy { get; set; }
    public DateOnly? BattleDate { get; set; }
}