namespace BonusPointManager.Models.Eurobonus
{
  public class EurobonusPointType
  {
    public int Id { get; set; }
    public enum PointType
    {
      Basic,
      Extra,
      Status
    }
  }
}
