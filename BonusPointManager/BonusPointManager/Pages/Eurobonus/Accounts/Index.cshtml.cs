using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;

namespace BonusPointManager.Pages.Eurobonus.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly BonusPointManager.Data.BonusPointManagerContext _context;

        public IndexModel(BonusPointManager.Data.BonusPointManagerContext context)
        {
            _context = context;
        }

        public IList<EurobonusAccount> EurobonusAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EurobonusAccounts != null)
            {
                EurobonusAccount = await _context.EurobonusAccounts.ToListAsync();
            }
        }
    }
}
