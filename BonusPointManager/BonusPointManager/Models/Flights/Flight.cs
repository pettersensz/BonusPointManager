using BonusPointManager.Models.Person;

namespace BonusPointManager.Models.Flights
{
  public class Flight
  {
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public Airport DepartureAirport { get; set; }
    public Airport ArrivalAirport { get; set; }
    public Airline OperatingAirline { get; set; }
    public DateTime DepartureTimeUtc { get; set; }
    public DateTime ArrivalTimeUtc { get; set; }
    public Aircraft Aircraft { get; set; }
    public ICollection<Passenger> Passengers { get; set; }
  }
}
