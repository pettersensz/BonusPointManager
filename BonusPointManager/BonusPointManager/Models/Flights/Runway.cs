using BonusPointManager.Models.Conversion;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonusPointManager.Models.Flights
{
  public class Runway
  {
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int LengthFt { get; set; }
    [NotMapped]
    public int LengthM { get => LengthConversion.ConvertFeetToMeters(LengthFt); }

    public int WidthFt { get; set; }
    [NotMapped]
    public int WidthM { get => LengthConversion.ConvertFeetToMeters(WidthFt); }

    public SurfaceType RunwaySurface { get; set; }

    public List<RunwayHeading> RunwayHeadings { get; set; }

    public int AirportId { get; set; }
    public Airport Airport { get; set; }
  }
}
