using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class IndexModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public IndexModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public IList<Airport> Airport { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.Airports != null)
      {
        Airport = await _context.Airports.Include(a => a.Runways).ToListAsync();
      }
    }
  }
}
