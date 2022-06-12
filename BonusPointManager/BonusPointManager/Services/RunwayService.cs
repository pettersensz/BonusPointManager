using BonusPointManager.Models.Flights;
using System.Globalization;
using System.Reflection;

namespace BonusPointManager.Services
{
  public class RunwayService
  {
    readonly string _pathToRunwayFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Data\runways.csv";
    readonly NumberStyles _numberStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
    readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");

    public int RunwaysInFileForIcaoCode(string icaoCode)
    {
      var count = 0;

      using var reader = new StreamReader(_pathToRunwayFile);
      var line = reader.ReadLine();

      while (line != null)
      {
        var runwayDetails = line.Split(',');
        var runwayIcaoCode = runwayDetails[2].Trim('"');
        if(runwayIcaoCode == icaoCode)
        {
          count++;
        }
        line = reader.ReadLine();
      }

      return count;
    }

    public List<Runway> GetRunwaysForIcaoCode(string icaoCode)
    {
      var runwayList = new List<Runway>();
      using var reader = new StreamReader(_pathToRunwayFile);
      var line = reader.ReadLine();

      while (line != null)
      {
        var runwayDetails = line.Split(',');
        var runwayIcaoCode = runwayDetails[2].Trim('"');
        if (runwayIcaoCode == icaoCode)
        {
          var runway = new Runway();
          runway.LengthFt = Int32.Parse(runwayDetails[3]);
          runway.WidthFt = Int32.Parse(runwayDetails[4]);
          if (runwayDetails[5].Trim('"') == "ASP" || runwayDetails[5].Trim('"') == "Asphalt") runway.RunwaySurface = SurfaceType.Asphalt;

          var heading1 = new RunwayHeading();
          heading1.Name = runwayDetails[8].Trim('"');
          heading1.LatitudeDeg = decimal.Parse(runwayDetails[9], _numberStyle, _culture);
          heading1.LongitudeDeg = decimal.Parse(runwayDetails[10], _numberStyle, _culture);
          heading1.ElevationFt = Int32.Parse(runwayDetails[11]);
          heading1.HeadingDeg = decimal.Parse(runwayDetails[12], _numberStyle, _culture);
          var isAValue1 = Int32.TryParse(runwayDetails[13], out var threshold1);
          if (isAValue1) heading1.DisplacedThresholdFt = threshold1;
          else heading1.DisplacedThresholdFt = 0;
          runway.RunwayHeading1 = heading1;

          var heading2 = new RunwayHeading();
          heading2.Name = runwayDetails[14].Trim('"');
          heading2.LatitudeDeg = decimal.Parse(runwayDetails[15], _numberStyle, _culture);
          heading2.LongitudeDeg = decimal.Parse(runwayDetails[16], _numberStyle, _culture);
          heading2.ElevationFt = Int32.Parse(runwayDetails[17]);
          heading2.HeadingDeg = decimal.Parse(runwayDetails[18], _numberStyle, _culture);
          var isAValue2 = Int32.TryParse(runwayDetails[19], out var threshold2);
          if(isAValue2) heading2.DisplacedThresholdFt = threshold2;
          else heading2.DisplacedThresholdFt = 0;
          runway.RunwayHeading2 = heading2;

          runway.Name = heading1.Name + "-" + heading2.Name;

          runwayList.Add(runway);
        }
        line = reader.ReadLine();
      }
      return runwayList;
    }
  }
}
