using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Transfusion.Storage;

namespace Transfusion.StateOfVessels
{
    public class CreateModel : PageModel
    {
        private readonly Transfusion.Storage.Database _context;

        public CreateModel(Transfusion.Storage.Database context)
        {
            _context = context;
        }


        /// <summary>
        /// Создание начального состояния 
        /// </summary>
        /// <param name="vesselid">Идентификатор сосуда</param>
        /// <returns></returns>
        public IActionResult OnGet(Guid? vesselid, StateType type)
        {
            // Вычисление идентификатора стартового события:
            // Сосуд
            Vessel vessel = _context.Vessels.Find(vesselid);
            State state = _context.States.FirstOrDefault(a => a.PuzzleID == vessel.PuzzleID && a.SType == type);

            // Создать сосуд и сохранить в нем идентификатор головоломки
            StateOfVessel = new StateOfVessel()
            {
                State = state,
                StateID = state.ID,
                Vessel = vessel,
                VesselID = vesselid.Value
            };
            return Page();
        }

        [BindProperty]
        public StateOfVessel StateOfVessel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StatesOfVessels.Add(StateOfVessel);
            Vessel vessel = _context.Vessels.Find(StateOfVessel.VesselID);
            await _context.SaveChangesAsync();

            // Возврат к просмотру головоломки
            return RedirectToPage("/Puzzles/Details", new { id = vessel.PuzzleID });
        }
    }
}
