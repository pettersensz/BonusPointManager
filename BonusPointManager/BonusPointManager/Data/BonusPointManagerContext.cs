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

    public DbSet<EurobonusTransaction> EurobonusTransaction { get; set; }
    public DbSet<EurobonusPointType> EurobonusPointType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EurobonusTransaction>().Property(ebt => ebt.PointType).HasConversion<int>();
      modelBuilder.Entity<EurobonusPointType>().Property(ept => ept.Id).HasConversion<int>();

      modelBuilder.Entity<EurobonusPointType>().HasData(
        Enum.GetValues(typeof(PointType)).Cast<PointType>().
        Select(e => new EurobonusPointType
        {
          Id = e,
          PointType = e.ToString()
        })
        );

      base.OnModelCreating(modelBuilder);
    }
  }
}
