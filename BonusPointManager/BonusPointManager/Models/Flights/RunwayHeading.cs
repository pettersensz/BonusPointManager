using BonusPointManager.Models.Conversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonusPointManager.Models.Flights
{
  public class RunwayHeading
  {
    public int Id { get; set; }
    public string Name { get; set; }

    [Column(TypeName = "decimal(4,1)")]
    [DisplayFormat(DataFormatString = "{0:0.0}")]
    [Display(Name = "Heading (deg)")]
    public decimal HeadingDeg { get; set; }

    [Display(Name = "Displaced Threshold (ft)")]
    public int DisplacedThresholdFt { get; set; }
    [NotMapped]
    public int DisplacedThresholdM { get => LengthConversion.ConvertFeetToMeters(DisplacedThresholdFt); }

    [Column(TypeName = "decimal(17,14)")]
    [DisplayFormat(DataFormatString = "{0:0.0000}")]
    [Display(Name = "Latitude (deg)")]
    public decimal LatitudeDeg { get; set; }

    [Column(TypeName = "decimal(17,14)")]
    [DisplayFormat(DataFormatString = "{0:0.0000}")]
    [Display(Name = "Longitude (deg)")]
    public decimal LongitudeDeg { get; set; }

    [Display(Name = "Elevation (ft)")]
    public int ElevationFt { get; set; }

    
    public int RunwayId { get; set; }
   
    public Runway Runway { get; set; }

    [NotMapped]
    public int LdaFt { get => Runway.LengthFt - DisplacedThresholdFt; }

    [NotMapped]
    public int LdaM { get => LengthConversion.ConvertFeetToMeters(LdaFt); }

    [NotMapped]
    public int ToraFt { get => Runway.LengthFt; }

    [NotMapped]
    public int ToraM { get => LengthConversion.ConvertFeetToMeters(ToraFt); }
  }
}
