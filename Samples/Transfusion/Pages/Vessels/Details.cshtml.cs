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
    public class DetailsModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public DetailsModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

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
    }
}
