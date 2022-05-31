namespace BonusPointManager.Models.Flights
{
  public class Runway
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Heading { get; set; }
    public int DisplacedThresholdFt { get; set; }
  }
}
