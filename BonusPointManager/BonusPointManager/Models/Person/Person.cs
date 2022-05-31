using BonusPointManager.Models.Eurobonus;
using BonusPointManager.Models.Flights;

namespace BonusPointManager.Models.Person
{
  public class Person
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public EurobonusAccount Account { get; set; }
    public List<Flight> Flights { get; set; }
  }
}
