using BonusPointManager.Models.Person;
using System.ComponentModel.DataAnnotations;

namespace BonusPointManager.Models.Flights
{
  public class Flight
  {
    public int Id { get; set; }
    [Display(Name = "Flight Number")]
    public string FlightNumber { get; set; }
    public Airport DepartureAirport { get; set; }
    public Airport ArrivalAirport { get; set; }
    public Airline OperatingAirline { get; set; }
    
    [Display(Name = "Departure Time UTC")]
    public DateTime DepartureTimeUtc { get; set; }
    
    [Display(Name = "Arrival Time UTC")]
    public DateTime ArrivalTimeUtc { get; set; }
    public Aircraft Aircraft { get; set; }
    public ICollection<Passenger> Passengers { get; set; }
  }
}
