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
    public class SolutionModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public SolutionModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }

        public Puzzle Puzzle { get; set; }

        /// <summary>
        /// Матрица визуализации состояний
        /// </summary>
        public List<List<int>> Matrix { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Моя головоломка
            Puzzle = await _context.Puzzles.FirstOrDefaultAsync(m => m.ID == id);

            if (Puzzle == null)
            {
                return NotFound();
            }

            // Решение головоломки
            // -------------------
            // Загрузка начального и конечного состояний
            State start = _context.GetState(id.Value, StateType.Start);
            State final = _context.GetState(id.Value, StateType.Final);

            // Добавление ходов для начального состояния
            _context.AddMoves(start);

            Move move;
            move = _context.Moves.FirstOrDefault(a => a.ToState == null);

            while (move != null)
            {
                // Построение следующего состояния
                State newState = State.NextState(move);

                // Поиск нового состояния в базе
                State oldState = null;
                // Все сохраненные состояния этой головоломки
                foreach (var s in _context.States.Where(a => a.PuzzleID == id && a.SType == StateType.Intermediate).ToList())
                {
                    if (s == newState)
                    {
                        oldState = s;
                        break;
                    }
                }

                if (oldState != null)
                {
                    // Состояние уже есть в базе
                    move.ToState = oldState;
                }
                else
                {
                    // Новое состояние
                    move.ToState = newState;
                    // Проверка на решение задачи
                    if (newState == final)
                    {
                        newState.SType = StateType.Solution;
                    }
                    // Добавление в базу данных
                    _context.States.Add(newState);
                    _context.AddMoves(newState);
                }
                // Сохранение изменений
                _context.SaveChanges();

                move = _context.Moves.FirstOrDefault(a => a.ToState == null);

                // решение найдено - выходим из цикла
                if (newState.SType == StateType.Solution) { break; }
            }

            // Построение матрицы для визуализации
            Matrix = new List<List<int>>();

            /*
            foreach (var s in _context.States.Where(a => a.PuzzleID == id).OrderBy(a => a.SType).ToList())
            {
                // Строка состояния для визуализации
                var list = s.StateOfVessels.OrderBy(a => a.Vessel.Number).Select(a => a.Value.HasValue ? a.Value.Value : -1).ToList();
                Matrix.Add(list);
            }
            */

            State state = _context.GetState(id.Value, StateType.Solution);
            // Строка состояния для визуализации
            var list = state.StateOfVessels.Select(a => a.Value.Value).ToList();
            Matrix.Add(list);

            List<Guid> states = new List<Guid>() { state.ID };
            while (state.SType != StateType.Start)
            {
                // Переход к предыдущему состоянию
                move = _context.Moves.First(a => a.ToState.ID == state.ID && !states.Contains(a.FromState.ID));
                state = move.FromState;
                states.Add(state.ID);
                // Строка состояния для визуализации
                list = state.StateOfVessels.Select(a => a.Value.Value).ToList();
                Matrix.Add(list);
            }


            return Page();
        }
    }
}
