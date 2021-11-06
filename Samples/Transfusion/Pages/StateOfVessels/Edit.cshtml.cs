using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transfusion.Storage;

namespace Transfusion.StateOfVessels
{
    public class EditModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public EditModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        [BindProperty]
        public StateOfVessel StateOfVessel { get; set; }

        public IActionResult OnGetAsync(Guid id)
        {
            StateOfVessel = _context.StatesOfVessels.Find(id);

            if (StateOfVessel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StateOfVessel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateOfVesselExists(StateOfVessel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Возврат к просмотру головоломки
            Vessel vessel = _context.Vessels.Find(StateOfVessel.VesselID);
            return RedirectToPage("/Puzzles/Details", new { id = vessel.PuzzleID });
        }

        private bool StateOfVesselExists(Guid id)
        {
            return _context.StatesOfVessels.Any(e => e.ID == id);
        }
    }
}
