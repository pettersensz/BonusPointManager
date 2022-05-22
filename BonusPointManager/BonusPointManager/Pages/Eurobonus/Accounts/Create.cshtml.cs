using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BonusPointManager.Data;
using BonusPointManager.Models.Eurobonus;

namespace BonusPointManager.Pages.Eurobonus.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly BonusPointManagerContext _context;

        public CreateModel(BonusPointManager.Data.BonusPointManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EurobonusAccount EurobonusAccount { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EurobonusAccounts.Add(EurobonusAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
