using BonusPointManager.Models.Flights;
using System.Globalization;
using System.Reflection;

namespace BonusPointManager.Services
{
  public class AirportService
  {
    // TODO maybe move to appsettings file to make it replaceable
    string PathToAirportFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Data\airports.csv";

    public bool AirportExistsInFileIcao(string IcaoCode)
    {
      IcaoCode = IcaoCode.ToUpper();
      using var reader = new StreamReader(PathToAirportFile);
      var line = reader.ReadLine();
      while (line != null)
      {
        var airportDetails = line.Split(',');
        var airportIcaoCode = airportDetails[1].Trim('"');
        if (airportIcaoCode == IcaoCode)
        {
          return true;
        }
        line = reader.ReadLine();
      }
      return false;
    }

    public Airport GetAirportIcao(string IcaoCode)
    {
      IcaoCode = IcaoCode.ToUpper();

      var airport = new Airport();

      using var reader = new StreamReader(PathToAirportFile);
      var line = reader.ReadLine();
      while (line != null)
      {
        var airportDetails = line.Split(',');
        var airportIcaoCode = airportDetails[1].Trim('"');
        if (airportIcaoCode == IcaoCode)
        {
          airport = ReadAirportDataFromStringArray(airportDetails);
          break;
        }
        line = reader.ReadLine();
      }

      return airport;
    }

    private Airport ReadAirportDataFromStringArray(string[] airportDetails)
    {
      var airport = new Airport();
      // TODO All strings must be trimmed for quotes ""
      airport.IcaoCode = airportDetails[1].Trim('"');
      airport.Name = airportDetails[3].Trim('"');

      // Nedd to take into account that airport name can have a comma in it
      var add = 0;
      var style = NumberStyles.AllowDecimalPoint;
      var culture = CultureInfo.CreateSpecificCulture("en-US");
      decimal latitudeDeg;
      var commaFreeName = Decimal.TryParse(airportDetails[4], style, culture, out latitudeDeg);

      if (!commaFreeName)
      {
        airport.Name = airportDetails[3].Trim('"') + "," + airportDetails[4].Trim('"');
        add++;
      }

      // TODO decimals get read with all digits, but saved to DB with only two digits. Why?
      airport.LatitudeDeg = Decimal.Parse(airportDetails[4 + add], style, culture);
      airport.LongitudeDeg = Decimal.Parse(airportDetails[5 + add], style, culture);

      airport.ElevationFt = Int32.Parse(airportDetails[6 + add]);

      airport.Country = airportDetails[8 + add].Trim('"');

      airport.IataCode = airportDetails[13 + add].Trim('"');

      return airport;
    }

    public bool AirportExistsInFileIata(string IataCode)
    {
      IataCode = IataCode.ToUpper();
      using var reader = new StreamReader(PathToAirportFile);
      var line = reader.ReadLine();
      while (line != null)
      {
        var airportDetails = line.Split(',');
        // TODO deal with airports with , in name, will offsett the index
        var airportIataCode = airportDetails[13].Trim('"');
        if (airportIataCode == IataCode)
        {
          return true;
        }
        line = reader.ReadLine();
      }
      return false;
    }
  }
}
