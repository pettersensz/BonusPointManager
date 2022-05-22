using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;

namespace BonusPointManager.Pages.Eurobonus.Accounts
{
    public class EditModel : PageModel
    {
        private readonly BonusPointManager.Data.BonusPointManagerContext _context;

        public EditModel(BonusPointManager.Data.BonusPointManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EurobonusAccount EurobonusAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EurobonusAccounts == null)
            {
                return NotFound();
            }

            var eurobonusaccount =  await _context.EurobonusAccounts.FirstOrDefaultAsync(m => m.Id == id);
            if (eurobonusaccount == null)
            {
                return NotFound();
            }
            EurobonusAccount = eurobonusaccount;
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

            _context.Attach(EurobonusAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EurobonusAccountExists(EurobonusAccount.Id))
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

        private bool EurobonusAccountExists(int id)
        {
          return _context.EurobonusAccounts.Any(e => e.Id == id);
        }
    }
}
