using System.ComponentModel.DataAnnotations;

namespace BonusPointManager.Models.Eurobonus
{
  public class EurobonusTransaction
  {
    public int ID { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Acquired Date")]
    public DateTime AcquiredDate { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Expiry Date")]
    public DateTime ExpiryDate { get; set; }
    public int Amount { get; set; }
    [Display(Name = "Point Type")]
    public PointType PointType { get; set; }
    public string Description { get; set; }

    [Display(Name = "Eurobonus Account")]
    public EurobonusAccount Account { get; set; }
  }
}
