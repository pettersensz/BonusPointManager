using System.ComponentModel.DataAnnotations;

namespace BonusPointManager.Models.Eurobonus
{
  [Display(Name = "Eurobonus Account")]
  public class EurobonusAccount
  {
    public int Id { get; set; }
    [Display(Name = "Account Number")]
    public int AccountNumber { get; set; }
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Signup Date")]
    public DateTime SignupDate { get; set; }

    [Display(Name = "Status Level")]
    public StatusLevel StatusLevel { get; set; }

    // Not-mapped properties
    [Display(Name = "Current Period")]
    public string CurrentPeriodString {get => GetCurrentPeriodAsString();}

    public string GetCurrentPeriodAsString()
    {
      var currentPeriod = GetCurrentPeriodStartDate().ToShortDateString() + " - " + GetCurrentPeriodEndDate().ToShortDateString();
      return currentPeriod;
    }

    public DateTime GetCurrentPeriodStartDate()
    {
      var startOfFirstPeriod = new DateTime(SignupDate.Year, SignupDate.Month, 1);
      var yearsSinceSignup = DateTime.Now.Year - SignupDate.Year;
      var currentStartOfPeriod = startOfFirstPeriod.AddYears(yearsSinceSignup);
      if (currentStartOfPeriod > DateTime.Now) currentStartOfPeriod = currentStartOfPeriod.AddYears(-1);
      return currentStartOfPeriod;
    }

    public DateTime GetCurrentPeriodEndDate()
    {
      var startOfFirstPeriod = new DateTime(SignupDate.Year, SignupDate.Month, 1);
      var yearsSinceSignup = DateTime.Now.Year - SignupDate.Year;
      var endOfFirstPeriod = startOfFirstPeriod.AddYears(1).AddDays(-1);
      var currentEndOfPeriod = endOfFirstPeriod.AddYears(yearsSinceSignup);
      if (currentEndOfPeriod > DateTime.Now.AddYears(1)) currentEndOfPeriod = currentEndOfPeriod.AddYears(-1);
      return currentEndOfPeriod;
    }

  }

}
