using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Eurobonus.Transactions
{
  public class IndexModel : PageModel
  {
    private readonly Data.BonusPointManagerContext _context;

    public IndexModel(Data.BonusPointManagerContext context)
    {
      _context = context;
    }

    public IList<EurobonusTransaction> EurobonusTransaction { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.EurobonusTransaction != null)
      {
        EurobonusTransaction = await _context.EurobonusTransaction.ToListAsync();
      }
    }
  }
}
