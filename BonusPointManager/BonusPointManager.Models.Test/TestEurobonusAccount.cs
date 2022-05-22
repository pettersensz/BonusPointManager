using FluentAssertions;
using BonusPointManager.Models.Eurobonus;

namespace BonusPointManager.Models.Test
{
  public class TestEurobonusAccount
  {
    private EurobonusAccount account;
    public TestEurobonusAccount()
    {
      account = new EurobonusAccount
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
      var currentPeriodStartDate = account.GetCurrentPeriodStartDate();
      currentPeriodStartDate.Should().BeOnOrBefore(DateTime.Now);

      var timeDifference = DateTime.Now - currentPeriodStartDate;
      timeDifference.Should().BeLessThanOrEqualTo(new TimeSpan(366, 0, 0, 0));
    }

    [Fact]
    public void GetCurrentPeriodEndDateReturnsDateAfterNow()
    {
      var currentPeriodEndDate = account.GetCurrentPeriodEndDate();
      currentPeriodEndDate.Should().BeOnOrAfter(DateTime.Now);

      var timeDifference = currentPeriodEndDate - DateTime.Now;
      timeDifference.Should().BeLessThanOrEqualTo(new TimeSpan(366, 0, 0, 0));
    }
  }
}