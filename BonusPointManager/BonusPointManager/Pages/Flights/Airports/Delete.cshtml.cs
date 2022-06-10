using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class DeleteModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public DeleteModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Airport Airport { get; set; }

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
      else
      {
        Airport = airport;
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.Airports == null)
      {
        return NotFound();
      }
      var airport = await _context.Airports.FindAsync(id);

      if (airport != null)
      {
        Airport = airport;
        _context.Airports.Remove(Airport);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
