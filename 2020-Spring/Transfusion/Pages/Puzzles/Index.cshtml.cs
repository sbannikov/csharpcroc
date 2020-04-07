using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Transfusion.Storage;

namespace Transfusion
{
    public class IndexModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public IndexModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        public IList<Puzzle> Puzzle { get;set; }

        public async Task OnGetAsync()
        {
            Puzzle = await _context.Puzzles.ToListAsync();
        }
    }
}
