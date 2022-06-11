using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using BonusPointManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class LookupModel : PageModel
  {
    private readonly AirportService _airportService = new AirportService();
    private readonly BonusPointManagerContext _context;

    public LookupModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public Airport Airport { get; set; }

    [BindProperty]
    public string IcaoCode { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      var existInDb = _context.Airports.Any(a => a.IcaoCode == IcaoCode.ToUpper());

      if (existInDb)
      {
        ViewData["Something"] = IcaoCode.ToUpper() + " already exists in the database";
        return Page();
      }
      
      var existInFile = _airportService.AirportExistsInFileIcao(IcaoCode);
      Airport = _airportService.GetAirportIcao(IcaoCode);

      if (existInFile)
      {
        ViewData["Something"] = IcaoCode.ToUpper() + " was added to the database";
        _context.Airports.Add(Airport);
        await _context.SaveChangesAsync();
      }
      else
      {
        ViewData["Something"] = IcaoCode.ToUpper() + " was not found";
      }


      return Page();
    }

  }
}
