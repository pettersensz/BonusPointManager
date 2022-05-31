namespace BonusPointManager.Models.Flights
{
  public class Airline
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string IataCode { get; set; }
    public string IcaoCode { get; set; }
    public string Callsign { get; set; }
    public string Abbreviation { get; set; }
  }
}
