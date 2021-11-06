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
    public class DetailsModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public DetailsModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        /// <summary>
        /// Головоломка
        /// </summary>
        public Puzzle Puzzle { get; set; }

        /// <summary>
        /// Начальное состояние головоломки
        /// </summary>
        public List<StateOfVessel> StartState { get; set; }

        /// <summary>
        /// Целевое состояние головоломки
        /// </summary>
        public List<StateOfVessel> FinalState { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Загрузка головоломки
            Puzzle = await _context.Puzzles
                .Include("Vessels")
                .Include("States")
                .FirstOrDefaultAsync(m => m.ID == id);

            // Проверка на существование объекта
            if (Puzzle == null)
            {
                return NotFound();
            }

            // Загрузка начального и конечного состояний
            State start = _context.GetState(id.Value, StateType.Start);
            State final = _context.GetState(id.Value, StateType.Final);

            // Список
            StartState = _context.StatesOfVessels.Where(a => a.State.ID == start.ID).ToList();
            FinalState = _context.StatesOfVessels.Where(a => a.State.ID == final.ID).ToList();

            return Page();
        }
    }
}
