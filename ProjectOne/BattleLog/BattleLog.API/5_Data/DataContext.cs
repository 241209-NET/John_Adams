using Microsoft.EntityFrameworkCore;
using BattleLog.API.Model;

namespace BattleLog.API.Data;

public partial class DataContext : DbContext
{
    public DataContext(){}
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Enemy> Enemies { get; set; }

    public virtual DbSet<Battle> Battles { get; set; }

}