using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BonusPointManager.Data;
using BonusPointManager.Models.Person;

namespace BonusPointManager.Pages.Person
{
    public class DeleteModel : PageModel
    {
        private readonly BonusPointManagerContext _context;

        public DeleteModel(BonusPointManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Passenger Passenger { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var passenger = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            if (passenger == null)
            {
                return NotFound();
            }
            else 
            {
                Passenger = passenger;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }
            var passenger = await _context.Persons.FindAsync(id);

            if (passenger != null)
            {
                Passenger = passenger;
                _context.Persons.Remove(Passenger);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
