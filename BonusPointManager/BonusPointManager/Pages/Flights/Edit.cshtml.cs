using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights
{
  public class EditModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public EditModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Flight Flight { get; set; } = default!;

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
      Flight = flight;
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

      _context.Attach(Flight).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FlightExists(Flight.Id))
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

    private bool FlightExists(int id)
    {
      return _context.Flights.Any(e => e.Id == id);
    }
  }
}
