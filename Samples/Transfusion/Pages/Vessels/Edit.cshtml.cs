using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transfusion.Storage;

namespace Transfusion.Vessels
{
    public class EditModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public EditModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        [BindProperty]
        public Vessel Vessel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vessel = await _context.Vessels.FirstOrDefaultAsync(m => m.ID == id);

            if (Vessel == null)
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

            _context.Attach(Vessel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VesselExists(Vessel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Возврат к просмотру головоломки
            return RedirectToPage("/Puzzles/Details", new { id = Vessel.PuzzleID });
        }

        private bool VesselExists(Guid id)
        {
            return _context.Vessels.Any(e => e.ID == id);
        }
    }
}
