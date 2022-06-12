using BonusPointManager.Data;
using BonusPointManager.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BonusPointManager.Pages.Flights
{
  public class EditModel : PageModel
  {
    private readonly BonusPointManagerContext _context;
    public List<SelectListItem> DepartureAirportList;
    public List<SelectListItem> ArrivalAirportList;

    public EditModel(BonusPointManagerContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Flight Flight { get; set; } = default!;

    [BindProperty(Name = "DepartureAirportId")]
    public int? SelectedDepartureAirportId { get; set; }

    [BindProperty(Name = "ArrivalAirportId")]
    public int? SelectedArrivalAirportId { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Flights == null)
      {
        return NotFound();
      }

      var flight = await _context.Flights.FirstOrDefaultAsync(m => m.Id == id);
      if (flight == null)
      {
        return NotFound();
      }
      Flight = flight;

      DepartureAirportList = new List<SelectListItem>();
      DepartureAirportList.Add(new SelectListItem { Text = "Select Departure Airport", Value = "" });
      foreach (var airport in _context.Airports.OrderBy(a => a.IataCode)) 
      {
        var newItem = new SelectListItem { Text = airport.IataCode, Value = airport.Id.ToString() };
        if(airport.IataCode == Flight.DepartureAirport?.IataCode)
        {
          newItem.Selected = true;
        }
        DepartureAirportList.Add(newItem);
      }

      ArrivalAirportList = new List<SelectListItem>();
      ArrivalAirportList.Add(new SelectListItem { Text = "Select Arrival Airport", Value = "" });
      foreach (var airport in _context.Airports.OrderBy(a => a.IataCode))
      {
        var newItem = new SelectListItem { Text = airport.IataCode, Value = airport.Id.ToString() };
        if (airport.IataCode == Flight.ArrivalAirport?.IataCode)
        {
          newItem.Selected = true;
        }
        ArrivalAirportList.Add(newItem);
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

      var departureAirport = _context.Airports.FirstOrDefault(a => a.Id == SelectedDepartureAirportId);
      if(departureAirport != null) Flight.DepartureAirport = departureAirport;

      var arrivalAirport = _context.Airports.FirstOrDefault(a => a.Id == SelectedArrivalAirportId);
      if (arrivalAirport != null) Flight.ArrivalAirport = arrivalAirport;

      _context.Attach(Flight).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FlightExists(Flight.Id))
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

    private bool FlightExists(int id)
    {
      return _context.Flights.Any(e => e.Id == id);
    }
  }
}
