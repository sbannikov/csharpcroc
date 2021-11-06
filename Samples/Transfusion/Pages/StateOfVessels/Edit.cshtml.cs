﻿using System;
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

            return RedirectToPage("./Index");
        }

        private bool StateOfVesselExists(Guid id)
        {
            return _context.StatesOfVessels.Any(e => e.ID == id);
        }
    }
}
