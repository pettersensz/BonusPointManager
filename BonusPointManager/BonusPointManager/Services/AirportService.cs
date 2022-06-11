using BonusPointManager.Models.Flights;
using System.Globalization;
using System.Reflection;

namespace BonusPointManager.Services
{
  public class AirportService
  {
    // TODO maybe move to appsettings file to make it replaceable
    readonly string _pathToAirportFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Data\airports.csv";
    readonly NumberStyles _numberStyle = NumberStyles.AllowDecimalPoint;
    readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");

    public bool AirportExistsInFileIcao(string IcaoCode)
    {
      IcaoCode = IcaoCode.ToUpper();
      using var reader = new StreamReader(_pathToAirportFile);
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

      using var reader = new StreamReader(_pathToAirportFile);
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
      
      airport.IcaoCode = airportDetails[1].Trim('"');
      airport.Name = airportDetails[3].Trim('"');

      var add = 0;

      if (AirportNameContainsComma(airportDetails[4]))
      {
        airport.Name = airportDetails[3].Trim('"') + "," + airportDetails[4].Trim('"');
        add++;
      }

      airport.LatitudeDeg = Decimal.Parse(airportDetails[4 + add], _numberStyle, _culture);
      airport.LongitudeDeg = Decimal.Parse(airportDetails[5 + add], _numberStyle, _culture);

      airport.ElevationFt = Int32.Parse(airportDetails[6 + add]);

      airport.Country = airportDetails[8 + add].Trim('"');

      airport.IataCode = airportDetails[13 + add].Trim('"');

      return airport;
    }

    private bool AirportNameContainsComma(string nextItemInArray)
    {
      return !Decimal.TryParse(nextItemInArray, _numberStyle, _culture, out _);
    }

    public bool AirportExistsInFileIata(string IataCode)
    {
      IataCode = IataCode.ToUpper();
      using var reader = new StreamReader(_pathToAirportFile);
      var line = reader.ReadLine();
      while (line != null)
      {
        var airportDetails = line.Split(',');
        string airportIataCode;
        if (AirportNameContainsComma(airportDetails[4]))
        {
          airportIataCode = airportDetails[14].Trim('"');
        }
        else
        {
          airportIataCode = airportDetails[13].Trim('"');
        }
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
