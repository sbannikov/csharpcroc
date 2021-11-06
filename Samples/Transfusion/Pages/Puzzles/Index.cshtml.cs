using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Transfusion.Storage;

namespace Transfusion.Puzzles
{
    public class IndexModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public IndexModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        public IList<Puzzle> Puzzle { get;set; }

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            // Список головоломок, отсортированный по имени
            Puzzle = await _context.Puzzles.OrderBy(a=>a.Name).ToListAsync();
        }
    }
}
