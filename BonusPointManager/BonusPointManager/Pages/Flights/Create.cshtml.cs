using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonusPointManager.Pages.Flights
{
  public class CreateModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public CreateModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public Flight Flight { get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Flights.Add(Flight);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
