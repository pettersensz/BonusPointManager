using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BonusPointManager.Pages.Eurobonus.Transactions
{
  public class CreateModel : PageModel
  {
    private readonly BonusPointManagerContext _context;
    public List<SelectListItem> AccountList;

    [BindProperty(Name = "accountId")]
    public int SelectedAccountId { get; set; }

    public CreateModel(BonusPointManagerContext context)
    {
      _context = context;
      AccountList = new List<SelectListItem>();
      foreach (var account in _context.EurobonusAccounts)
      {
        AccountList.Add(new SelectListItem { Text = account.AccountNumber.ToString() + ": " + account.Name, Value = account.Id.ToString() });
      }

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
      if (!ModelState.IsValid || _context.EurobonusTransactions == null || EurobonusTransaction == null)
      {
        return Page();
      }
      var account = _context.EurobonusAccounts.FirstOrDefault(a => a.Id == SelectedAccountId);
      if (account != null) EurobonusTransaction.Account = account;
      // TODO this logic should not live here
      EurobonusTransaction.ExpiryDate = account.GetCurrentPeriodEndDate().AddYears(4);

      _context.EurobonusTransactions.Add(EurobonusTransaction);

      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
