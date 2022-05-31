using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonusPointManager.Data;
using BonusPointManager.Models.Person;

namespace BonusPointManager.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly BonusPointManagerContext _context;
        public List<SelectListItem> AccountList;

        [BindProperty(Name = "accountId")]
        public int? SelectedAccountId { get; set; }

        public EditModel(BonusPointManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Passenger Passenger { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var passenger =  await _context.Persons.Include(p => p.Account).FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }
            Passenger = passenger;
            AccountList = new List<SelectListItem>();
            AccountList.Add(new SelectListItem { Text = "No Eurobonus Account", Value = "" });
            foreach (var account in _context.EurobonusAccounts)
            {
              var newItem = new SelectListItem { Text = account.AccountNumber.ToString() + ": " + account.Name, Value = account.Id.ToString() };
              if (account.Id == Passenger.Account?.Id)
              {
                newItem.Selected = true;
              }
              AccountList.Add(newItem);
            }
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

            var account = _context.EurobonusAccounts.FirstOrDefault(a => a.Id == SelectedAccountId);
            Passenger.Account = account;

            _context.Attach(Passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(Passenger.Id))
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

        private bool PassengerExists(int id)
        {
          return _context.Persons.Any(e => e.Id == id);
        }
    }
}
