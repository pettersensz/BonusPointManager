using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights
{
  public class DeleteModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public DeleteModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.Flights == null)
      {
        return NotFound();
      }
      var flight = await _context.Flights.FindAsync(id);

      if (flight != null)
      {
        Flight = flight;
        _context.Flights.Remove(Flight);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
