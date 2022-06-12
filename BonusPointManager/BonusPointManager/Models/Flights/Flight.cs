using BonusPointManager.Models.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonusPointManager.Models.Flights
{
  public class Flight
  {
    public int Id { get; set; }
    [Display(Name = "Flight Number")]
    public string FlightNumber { get; set; }

    [Display(Name = "Departure Airport")]
    public Airport DepartureAirport { get; set; }

    [Display(Name = "Arrival Airport")]
    public Airport ArrivalAirport { get; set; }
    public Airline OperatingAirline { get; set; }

    [Display(Name = "Departure Time (UTC)")]
    public DateTime DepartureTimeUtc { get; set; }

    [NotMapped]
    [Display(Name = "Departure Time (Local)")]
    public DateTime DepartureTimeLocal
    {
      get
      {
        return DepartureTimeUtc.ToLocalTime();
      }
      set
      {
        // TODO here need to think about time zone for airport and user..?
        DepartureTimeUtc = value.ToUniversalTime();
      }
    }

    [Display(Name = "Arrival Time (UTC)")]
    public DateTime ArrivalTimeUtc { get; set; }

    [NotMapped]
    [Display(Name = "Arrival Time (Local)")]
    public DateTime ArrivalTimeLocal
    {
      get
      {
        return ArrivalTimeUtc.ToLocalTime();
      }
      set
      {
        // TODO here need to think about time zone for airport and user..?
        ArrivalTimeUtc = value.ToUniversalTime();
      }
    }

    public Aircraft Aircraft { get; set; }
    public ICollection<Passenger> Passengers { get; set; }
  }
}
