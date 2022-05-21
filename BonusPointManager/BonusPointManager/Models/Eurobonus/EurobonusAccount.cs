using System.ComponentModel.DataAnnotations;

namespace BonusPointManager.Models.Eurobonus
{
  public class EurobonusAccount
  {
    public int Id { get; set; }
    public int AccountNumber { get; set; }
    public string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime SignupDate { get; set; }

    public StatusLevel StatusLevel { get; set; }

  }

}
