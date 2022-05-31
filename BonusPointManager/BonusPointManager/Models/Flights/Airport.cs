namespace BonusPointManager.Models.Flights
{
  public class Airport
  {
    public int Id { get; set; }
    public ICollection<Runway> Runways { get; set; }
    public string Country { get; set; }
    public string IataCode { get; set; }
    public string IcaoCode { get; set; }

    public decimal LatitudeDeg { get; set; }
    public decimal LongitudeDeg { get; set; }
    public int ElevationFt { get; set; }

    public string Name { get; set; }
    public string LongName { get; set; }
  }
}
