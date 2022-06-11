namespace BonusPointManager.Models.Flights
{
  public class Runway
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int LenghtFt { get; set; }
    public SurfaceType RunwaySurface { get; set; }
    public RunwayHeading RunwayHeading1 { get; set; }
    public RunwayHeading RunwayHeading2 { get; set; }
  }
}
