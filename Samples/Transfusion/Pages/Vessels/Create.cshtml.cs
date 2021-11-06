using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transfusion.Storage;

namespace Transfusion.Vessels
{
    public class CreateModel : PageModel
    {
        private readonly Database _context;

        public CreateModel(Database context)
        {
            _context = context;
        }

        /// <summary>
        /// Форма добавления нового сосуда
        /// </summary>
        /// <param name="puzzleid">Идентификатор головоломки</param>
        /// <returns></returns>
        public IActionResult OnGet(Guid puzzleid)
        {          
            ICollection<Vessel> vessels = _context.Puzzles.Find(puzzleid).Vessels;

            // Создать сосуд и сохранить в нем идентификатор головоломки
            Vessel = new Vessel()
            {
                PuzzleID = puzzleid,
                Number = (vessels.Any() ? vessels.Max(x => x.Number) : 0) + 1
            };
            return Page();
        }

        [BindProperty]
        public Vessel Vessel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Сохранение нового объекта в БД
            _context.Vessels.Add(Vessel);
            await _context.SaveChangesAsync();

            // Возврат к просмотру головоломки
            return RedirectToPage("/Puzzles/Details", new { id = Vessel.PuzzleID });
        }
    }
}
