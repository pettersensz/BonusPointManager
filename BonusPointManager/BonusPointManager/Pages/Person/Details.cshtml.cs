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
    public class DetailsModel : PageModel
    {
        private readonly BonusPointManagerContext _context;

        public DetailsModel(BonusPointManagerContext context)
        {
            _context = context;
        }

      public Passenger Passenger { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var passenger = await _context.Persons.Include(p => p.Account).FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
