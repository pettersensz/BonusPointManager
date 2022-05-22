using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Eurobonus.Transactions
{
  public class DetailsModel : PageModel
  {
    private readonly Data.BonusPointManagerContext _context;

    public DetailsModel(Data.BonusPointManagerContext context)
    {
      _context = context;
    }

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
  }
}
