using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using BonusPointManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class LookupIataModel : PageModel
  {
    private readonly AirportService _airportService = new AirportService();
    private readonly BonusPointManagerContext _context;
    public LookupIataModel(BonusPointManagerContext context)
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
    public string IataCode { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      var existInDb = _context.Airports.Any(a => a.IataCode == IataCode.ToUpper());

      if (existInDb)
      {
        ViewData["Message"] = IataCode.ToUpper() + " already exists in the database";
        return Page();
      }

      var existInFile = _airportService.AirportExistsInFileIata(IataCode);

      Airport = _airportService.GetAirportFromIataCode(IataCode);

      if (existInFile)
      {
        ViewData["Message"] = IataCode.ToUpper() + " was added to the database";
        _context.Airports.Add(Airport);
        await _context.SaveChangesAsync();
      }
      else
      {
        ViewData["Message"] = IataCode.ToUpper() + " was not found";
      }


      return Page();
    }
  }
}
