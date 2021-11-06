using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transfusion.Storage;

namespace Transfusion.Puzzles
{
    public class CreateModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public CreateModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Puzzle Puzzle { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Puzzles.Add(Puzzle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
