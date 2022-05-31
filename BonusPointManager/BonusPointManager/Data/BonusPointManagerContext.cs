using BonusPointManager.Models.Eurobonus;
using BonusPointManager.Models.Flights;
using BonusPointManager.Models.Person;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Data
{
  public class BonusPointManagerContext : DbContext
  {
    public BonusPointManagerContext(DbContextOptions<BonusPointManagerContext> options)
        : base(options)
    {
    }

    // Eurobonus
    public DbSet<EurobonusTransaction> EurobonusTransactions { get; set; }
    public DbSet<EurobonusPointType> EurobonusPointTypes { get; set; }
    public DbSet<EurobonusStatusLevel> EurobonusStatusLevels { get; set; }
    public DbSet<EurobonusAccount> EurobonusAccounts { get; set; }

    // Flights
    public DbSet<Aircraft> Aircraft { get; set; }
    public DbSet<Airline> Airlines { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Runway> Runways { get; set; }
    // Person
    public DbSet<Passenger> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EurobonusTransaction>().Property(ebt => ebt.PointType).HasConversion<int>();
      modelBuilder.Entity<EurobonusPointType>().Property(ept => ept.Id).HasConversion<int>();
      modelBuilder.Entity<EurobonusAccount>().Property(eba => eba.StatusLevel).HasConversion<int>();
      modelBuilder.Entity<EurobonusStatusLevel>().Property(ebsl => ebsl.Id).HasConversion<int>();

      modelBuilder.Entity<Flight>().HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(j => j.ToTable("PassengerFlights"));

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
