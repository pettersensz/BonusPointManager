using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonusPointManager.Pages.Eurobonus.Transactions
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
    public EurobonusTransaction EurobonusTransaction { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.EurobonusTransaction == null || EurobonusTransaction == null)
      {
        return Page();
      }

      _context.EurobonusTransaction.Add(EurobonusTransaction);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
