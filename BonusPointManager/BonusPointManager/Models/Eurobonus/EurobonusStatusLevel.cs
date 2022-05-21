namespace BonusPointManager.Models.Eurobonus
{
  public class EurobonusStatusLevel
  {
    public StatusLevel Id { get; set; }
    public string StatusLevel { get; set; }

  }


  public enum StatusLevel : int
  {
    Basic = 0,
    Silver = 1,
    Gold = 2,
    Diamond = 3,
    Pandion = 4,
  }
}
