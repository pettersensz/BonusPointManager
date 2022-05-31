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
    public class IndexModel : PageModel
    {
        private readonly BonusPointManagerContext _context;

        public IndexModel(BonusPointManagerContext context)
        {
            _context = context;
        }

        public IList<Passenger> Passenger { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Persons != null)
            {
                Passenger = await _context.Persons.Include(p => p.Account).ToListAsync();
            }
        }
    }
}
