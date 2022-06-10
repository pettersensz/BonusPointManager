using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights
{
  public class IndexModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public IndexModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public IList<Flight> Flight { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.Flights != null)
      {
        Flight = await _context.Flights.ToListAsync();
      }
    }
  }
}
