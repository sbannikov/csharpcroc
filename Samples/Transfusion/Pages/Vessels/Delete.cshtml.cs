using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Transfusion.Storage;

namespace Transfusion.Vessels
{
    public class DeleteModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public DeleteModel(Transfusion.Storage.Database context)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vessel = await _context.Vessels.FindAsync(id);
            // Сохранить идентификатор головоломки
            Guid? puzzleid = Vessel.PuzzleID;

            if (Vessel != null)
            {
                _context.Vessels.Remove(Vessel);
                await _context.SaveChangesAsync();
            }

            // Возврат к просмотру головоломки
            return RedirectToPage("/Puzzles/Details", new { id = puzzleid });
        }
    }
}
