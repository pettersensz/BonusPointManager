using BonusPointManager.Data;
using System.ComponentModel.DataAnnotations;

namespace BonusPointManager.Models.Eurobonus
{
  [Display(Name = "Eurobonus Account")]
  public class EurobonusAccount
  {
    private readonly BonusPointManagerContext _context;

    public EurobonusAccount(BonusPointManagerContext context)
    {
      _context = context;
    }

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
    [Display(Name = "Status Level Expiry Date")]
    public string StatusLevelExpiryString { get => GetStatusLevelExpiry().ToShortDateString(); }

    [Display(Name = "Current Period")]
    public string CurrentPeriodString {get => GetCurrentPeriodAsString();}

    [Display(Name = "Status Points This Period")]
    public int CurrentPeriodStatusPoints { get => GetCurrentPeriodStatusPoints(); }

    [Display(Name = "Extra Points This Period")]
    public int CurrentPeriodExtraPoints { get => GetCurrentPeriodExtraPoints(); }

    // Methods
    public DateTime GetStatusLevelExpiry()
    {
      var endOfPeriod = GetCurrentPeriodEndDate();
      var statusExpiry = endOfPeriod.AddMonths(3);
      return statusExpiry;
    }

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

    public int GetCurrentPeriodStatusPoints()
    {
      var transactions = _context.EurobonusTransactions
        .Where(p => p.Account.Id == Id)
        .Where(p => p.PointType == PointType.Status || p.PointType == PointType.Basic)
        .Where(p => p.AcquiredDate >= GetCurrentPeriodStartDate() && p.AcquiredDate <= GetCurrentPeriodEndDate());
      var sum = 0;
      foreach(var transaction in transactions)
      {
        sum += transaction.Amount;
      }
      return sum;
    }

    public int GetCurrentPeriodExtraPoints()
    {
      var transactions = _context.EurobonusTransactions
        .Where(p => p.Account.Id == Id)
        .Where(p => p.PointType == PointType.Basic || p.PointType == PointType.Extra)
        .Where(p => p.AcquiredDate >= GetCurrentPeriodStartDate() && p.AcquiredDate <= GetCurrentPeriodEndDate());
      var sum = 0;
      foreach (var transaction in transactions)
      {
        if (!CheckIfTransactionIsARefund(transaction))
        {
          sum += transaction.Amount;
        }
      }
      return sum;
    }

    public bool CheckIfTransactionIsARefund(EurobonusTransaction transaction)
    {
      if (transaction.PointType != PointType.Extra) return false;
      if (transaction.Description != "Scandinavian Airlines System") return false;
      if (transaction.Amount % 3000 != 0) return false;
      return true;
    }

  }

}
