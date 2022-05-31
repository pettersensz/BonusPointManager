using BonusPointManager.Models.Eurobonus;
using BonusPointManager.Models.Flights;

namespace BonusPointManager.Models.Person
{
  public class Passenger
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public EurobonusAccount Account { get; set; }
    public ICollection<Flight> Flights { get; set; }
  }
}
