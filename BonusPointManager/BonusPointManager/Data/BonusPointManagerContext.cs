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

    // TODO Rename to plural?
    public DbSet<EurobonusTransaction> EurobonusTransaction { get; set; }
    public DbSet<EurobonusPointType> EurobonusPointType { get; set; }
    public DbSet<EurobonusStatusLevel> EurobonusStatusLevel { get; set; }
    public DbSet<EurobonusAccount> EurobonusAccount { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EurobonusTransaction>().Property(ebt => ebt.PointType).HasConversion<int>();
      modelBuilder.Entity<EurobonusPointType>().Property(ept => ept.Id).HasConversion<int>();
      modelBuilder.Entity<EurobonusAccount>().Property(eba => eba.StatusLevel).HasConversion<int>();
      modelBuilder.Entity<EurobonusStatusLevel>().Property(ebsl => ebsl.Id).HasConversion<int>();

      modelBuilder.Entity<EurobonusPointType>().HasData(
        Enum.GetValues(typeof(PointType))
        .Cast<PointType>()
        .Select(e => new EurobonusPointType
        {
          Id = e,
          PointType = e.ToString()
        }));

      modelBuilder.Entity<EurobonusStatusLevel>().HasData(
        Enum.GetValues(typeof(StatusLevel))
        .Cast<StatusLevel>()
        .Select(e => new EurobonusStatusLevel
        {
          Id = e,
          StatusLevel = e.ToString()
        }));

      base.OnModelCreating(modelBuilder);
    }
  }
}
