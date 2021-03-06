using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Eurobonus.Transactions
{
  public class IndexModel : PageModel
  {
    private readonly BonusPointManagerContext _context;

    public IndexModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    public IList<EurobonusTransaction> EurobonusTransaction { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.EurobonusTransactions != null)
      {
        EurobonusTransaction = await _context.EurobonusTransactions.Include(t => t.Account).ToListAsync();
      }
    }
  }
}
