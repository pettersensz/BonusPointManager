using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights
{
  public class DetailsModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public DetailsModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public Flight Flight { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Flights == null)
      {
        return NotFound();
      }

      var flight = await _context.Flights.FirstOrDefaultAsync(m => m.Id == id);
      if (flight == null)
      {
        return NotFound();
      }
      else
      {
        Flight = flight;
      }
      return Page();
    }
  }
}
