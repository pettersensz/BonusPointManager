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

      var airport = _context.Airports.FirstOrDefault(a => a.Id == Airport.Id);
      if(airport == null) return NotFound();

      airport.Runways = runwayList;

      _context.Attach(airport).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AirportExists(Airport.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      ViewData["Message"] = runwaysFound.ToString() + " runways were found for " + Airport.IcaoCode;
      
      return Page();
    }
    // TODO Duplication from edit
    private bool AirportExists(int id)
    {
      return _context.Airports.Any(e => e.Id == id);
    }

  }
}
