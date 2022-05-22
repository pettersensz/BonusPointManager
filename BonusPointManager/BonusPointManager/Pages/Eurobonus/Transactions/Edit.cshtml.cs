using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Eurobonus.Transactions
{
  public class EditModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public EditModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    [BindProperty]
    public EurobonusTransaction EurobonusTransaction { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.EurobonusTransactions == null)
      {
        return NotFound();
      }

      var eurobonustransaction = await _context.EurobonusTransactions.FirstOrDefaultAsync(m => m.ID == id);
      if (eurobonustransaction == null)
      {
        return NotFound();
      }
      EurobonusTransaction = eurobonustransaction;
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

      _context.Attach(EurobonusTransaction).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EurobonusTransactionExists(EurobonusTransaction.ID))
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

    private bool EurobonusTransactionExists(int id)
    {
      return (_context.EurobonusTransactions?.Any(e => e.ID == id)).GetValueOrDefault();
    }
  }
}
