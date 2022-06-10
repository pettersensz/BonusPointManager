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
      var exist = _airportService.AirportExistsInFileIcao(IcaoCode);
      Airport = _airportService.GetAirportIcao(IcaoCode);

      if (exist)
      {
        ViewData["Something"] = IcaoCode + " is definitively an airport";
        _context.Airports.Add(Airport);
        await _context.SaveChangesAsync();
      }
      else
      {
        ViewData["Something"] = IcaoCode + " is NOT an airport";
      }


      return Page();
    }

  }
}
