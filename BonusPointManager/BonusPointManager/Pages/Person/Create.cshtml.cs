using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BonusPointManager.Data;
using BonusPointManager.Models.Person;

namespace BonusPointManager.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly BonusPointManagerContext _context;
        public List<SelectListItem> AccountList;

        [BindProperty(Name = "accountId")]
        public int? SelectedAccountId { get; set; }

        public CreateModel(BonusPointManagerContext context)
        {
          _context = context;
          AccountList = new List<SelectListItem>();
          AccountList.Add(new SelectListItem { Text = "No Eurobonus Account", Value = "" });
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
        public Passenger Passenger { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = _context.EurobonusAccounts.FirstOrDefault(a => a.Id == SelectedAccountId);
            Passenger.Account = account;

            _context.Persons.Add(Passenger);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
