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

            // Загрузка начального состояния
            State start = Puzzle.States.Where(a => a.SType == StateType.Start).FirstOrDefault();
            // Проверка на наличие стартового состояния
            if (start == null)
            {
                // Создание стартового состояния
                start = new State()
                {
                    PuzzleID = Puzzle.ID,
                    SType = StateType.Start
                };
                // Добавление в таблицу состояний
                _context.States.Add(start);
                // Сохранение изменений в БД
                await _context.SaveChangesAsync();
            }
            // Список
            StartState = _context.StatesOfVessels.Where(a => a.State.ID == start.ID).ToList();
           
            return Page();
        }
    }
}
