namespace BonusPointManager.Models.Flights
{
  public class RunwaySurface
  {
    public SurfaceType Id { get; set; }
    public string SurfaceType { get; set; }

  }

  public enum SurfaceType: int
  {
    Asphalt = 0,
    Concrete = 1,
    Gravel = 2,
    Grass = 3,
    GravelAndGrass = 4,
    Unknown = 5,
  }
}
