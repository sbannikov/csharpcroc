using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Transfusion.Storage;

namespace Transfusion.StateOfVessels
{
    public class DetailsModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public DetailsModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        public StateOfVessel StateOfVessel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StateOfVessel = await _context.StatesOfVessels.FirstOrDefaultAsync(m => m.ID == id);

            if (StateOfVessel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
