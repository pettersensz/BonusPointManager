using FluentAssertions;
using BonusPointManager.Models.Eurobonus;
using BonusPointManager.Data;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Models.Test
{
  public class TestEurobonusAccount
  {
    private readonly EurobonusAccount _account;
    private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=BonusPointManager.Data;Trusted_Connection=True;MultipleActiveResultSets=true";

    public TestEurobonusAccount()
    {
      var builder = new DbContextOptionsBuilder<BonusPointManagerContext>();
      //TODO Should probably use in-memory db for tests, don't want to save stuff to real db..
      builder.UseSqlServer(_connectionString);
      _account = new EurobonusAccount(new BonusPointManagerContext(builder.Options))
      {
        AccountNumber = 123456,
        SignupDate = new DateTime(2012, 7, 15),
        Name = "Test User",
        StatusLevel = StatusLevel.Gold,
      };
    }

    [Fact]
    public void GetCurrentPeriodStartDateReturnsDateBeforeNow()
    {
      var currentPeriodStartDate = _account.GetCurrentPeriodStartDate();
      currentPeriodStartDate.Should().BeOnOrBefore(DateTime.Now);

      var timeDifference = DateTime.Now - currentPeriodStartDate;
      timeDifference.Should().BeLessThanOrEqualTo(new TimeSpan(366, 0, 0, 0));
    }

    [Fact]
    public void GetCurrentPeriodEndDateReturnsDateAfterNow()
    {
      var currentPeriodEndDate = _account.GetCurrentPeriodEndDate();
      currentPeriodEndDate.Should().BeOnOrAfter(DateTime.Now);

      var timeDifference = currentPeriodEndDate - DateTime.Now;
      timeDifference.Should().BeLessThanOrEqualTo(new TimeSpan(366, 0, 0, 0));
    }
  }
}