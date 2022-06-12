using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class DetailsModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public DetailsModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public Airport Airport { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Airports == null)
      {
        return NotFound();
      }

      var airport = await _context.Airports.Include(a => a.Runways).ThenInclude(r => r.RunwayHeadings).FirstOrDefaultAsync(m => m.Id == id);
      if (airport == null)
      {
        return NotFound();
      }
      else
      {
        Airport = airport;
      }
      return Page();
    }
  }
}
