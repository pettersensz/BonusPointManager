namespace BonusPointManager.Models.Conversion
{
  public class LengthConversion
  {
    const double FeetToMeterFactor = 0.3048;

    public static int ConvertFeetToMeters(int lengthInFeet)
    {
      var lengthInMeters = lengthInFeet * FeetToMeterFactor;
      var rounded = (int)Math.Round(lengthInMeters);
      return rounded; 
    }

    public static int ConvertMetersToFeet(int lenghtInMeters)
    {
      var lengthInFeet = lenghtInMeters / FeetToMeterFactor;
      var rounded = (int)Math.Round(lengthInFeet);
      return rounded;
    }
  }
}
