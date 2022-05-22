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
    public class DetailsModel : PageModel
    {
        private readonly BonusPointManager.Data.BonusPointManagerContext _context;

        public DetailsModel(BonusPointManager.Data.BonusPointManagerContext context)
        {
            _context = context;
        }

      public EurobonusAccount EurobonusAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EurobonusAccounts == null)
            {
                return NotFound();
            }

            var eurobonusaccount = await _context.EurobonusAccounts.FirstOrDefaultAsync(m => m.Id == id);
            if (eurobonusaccount == null)
            {
                return NotFound();
            }
            else 
            {
                EurobonusAccount = eurobonusaccount;
            }
            return Page();
        }
    }
}
