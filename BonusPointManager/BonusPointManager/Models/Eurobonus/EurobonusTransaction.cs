using System.ComponentModel.DataAnnotations;

namespace BonusPointManager.Models.Eurobonus
{
  public class EurobonusTransaction
  {
    public int ID { get; set; }
    [DataType(DataType.Date)]
    public DateTime AcquiredDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }
    public int Amount { get; set; }
    public EurobonusPointType PointType { get; set; }
  }
}
