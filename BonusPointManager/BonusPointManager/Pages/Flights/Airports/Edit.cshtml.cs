using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights.Airports
{
  public class EditModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public EditModel(BonusPointManagerContext context)
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Airport).State = EntityState.Modified;

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

      return RedirectToPage("./Index");
    }

    private bool AirportExists(int id)
    {
      return _context.Airports.Any(e => e.Id == id);
    }
  }
}
