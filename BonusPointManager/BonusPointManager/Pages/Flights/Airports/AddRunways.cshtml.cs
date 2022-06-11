using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using BonusPointManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class AddRunwaysModel : PageModel
  {
    private readonly BonusPointManagerContext _context;
    private readonly RunwayService _runwayService = new RunwayService();
    public AddRunwaysModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Airport Airport { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Airports == null)
      {
        return NotFound();
      }

      var airport = await _context.Airports.FirstOrDefaultAsync(m => m.Id == id);
      if (airport == null)
      {
        return NotFound();
      }
      Airport = airport;
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var runwaysFound = _runwayService.RunwaysInFileForIcaoCode(Airport.IcaoCode);

      var runwayList = _runwayService.GetRunwaysForIcaoCode(Airport.IcaoCode);

      ViewData["Message"] = runwaysFound.ToString() + " runways were found for " + Airport.IcaoCode;
      
      return Page();
    }

  }
}
