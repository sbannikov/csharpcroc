using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaBattle.Data;

namespace SeaBattleMvc.Controllers
{
    /// <summary>
    /// Контроллер
    /// </summary>
    public class GameController : Controller
    {
        /// <summary>
        /// Действие по умолчанию
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Game game = Game.Load(@"c:\game.xml");
            Models.MvcField field = new Models.MvcField(game);
            return View(field);
        }

        public ActionResult Fire(int cx, int cy)
        {
            Game game = Game.Load(@"c:\game.xml");
            Models.MvcField field = new Models.MvcField(game);
            field.cell[cx, cy].State = State.Hit;
            return View("Index", field);
        }

    }
}