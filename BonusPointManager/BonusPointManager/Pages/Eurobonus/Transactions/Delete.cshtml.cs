using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Eurobonus.Transactions
{
  public class DeleteModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public DeleteModel(BonusPointManagerContext context)
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
      else
      {
        EurobonusTransaction = eurobonustransaction;
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.EurobonusTransactions == null)
      {
        return NotFound();
      }
      var eurobonustransaction = await _context.EurobonusTransactions.FindAsync(id);

      if (eurobonustransaction != null)
      {
        EurobonusTransaction = eurobonustransaction;
        _context.EurobonusTransactions.Remove(EurobonusTransaction);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
