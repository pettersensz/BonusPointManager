using BonusPointManager.Models.Flights;
using System.Globalization;

namespace BonusPointManager.Services
{
  public class AirportService
  {
    // TODO Hardcoded for now, find better solution
    const string PathToAirportFile = @"C:\Users\sigmundpe\Dropbox\Eurobonus\ourairports-data-main\ourairports-data-main\airports.csv";

    public bool AirportExistsInFileIcao(string IcaoCode)
    {
      IcaoCode = IcaoCode.ToUpper();
      using var reader = new StreamReader(PathToAirportFile);
      var line = reader.ReadLine();
      while(line != null)
      {
        var airportDetails = line.Split(',');
        var airportIcaoCode = airportDetails[1].Trim('"');
        if(airportIcaoCode == IcaoCode)
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
          // TODO All strings must be trimmed for quotes ""
          airport.IcaoCode = airportDetails[1];
          airport.Name = airportDetails[3];

          // Nedd to take into account that airport name can have a comma in it
          var add = 0;
          var style = NumberStyles.AllowDecimalPoint;
          var culture = CultureInfo.CreateSpecificCulture("en-US");
          decimal latitudeDeg;
          var commaFreeName = Decimal.TryParse(airportDetails[4], style, culture, out latitudeDeg);

          if (!commaFreeName)
          {
            airport.Name = airportDetails[3] + "," + airportDetails[4];
            add++;
          }
          
          // TODO decimals get read with all digits, but saved to DB with only two digits. Why?
          airport.LatitudeDeg = Decimal.Parse(airportDetails[4 + add], style, culture);
          airport.LongitudeDeg = Decimal.Parse(airportDetails[5 + add], style, culture);

          airport.ElevationFt = Int32.Parse(airportDetails[6 + add]);

          airport.Country = airportDetails[8 + add];

          airport.IataCode = airportDetails[13 + add];
          break;
        }
        line = reader.ReadLine();
      }
      
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
