using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonusPointManager.Models.Flights
{
  public class Airport
  {
    public int Id { get; set; }
    public ICollection<Runway> Runways { get; set; }

    [NotMapped]
    [Display(Name="Runways")]
    public int RunwayCount { get =>  Runways?.Count ?? 0; }

    public string Country { get; set; }
    public string IataCode { get; set; }
    public string IcaoCode { get; set; }

    [Column(TypeName = "decimal(10,7)")]
    [DisplayFormat(DataFormatString = "{0:0.0000}")]
    [Display(Name = "Latitude (deg)")]
    public decimal LatitudeDeg { get; set; }

    [Column(TypeName = "decimal(10,7)")]
    [DisplayFormat(DataFormatString = "{0:0.0000}")]
    [Display(Name = "Longitude (deg)")]
    public decimal LongitudeDeg { get; set; }

    [Display(Name = "Elevation (ft)")]
    public int ElevationFt { get; set; }

    public string Name { get; set; }
    public string LongName { get; set; }
  }
}
