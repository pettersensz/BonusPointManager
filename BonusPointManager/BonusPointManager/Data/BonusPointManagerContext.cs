using BonusPointManager.Models.Eurobonus;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Data
{
  public class BonusPointManagerContext : DbContext
  {
    public BonusPointManagerContext(DbContextOptions<BonusPointManagerContext> options)
        : base(options)
    {
    }

    public DbSet<EurobonusTransaction>? EurobonusTransaction { get; set; }
  }
}
