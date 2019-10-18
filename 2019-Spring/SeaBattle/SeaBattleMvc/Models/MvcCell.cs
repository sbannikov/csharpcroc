using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaBattleMvc.Models
{
    /// <summary>
    /// Клетка игрового поля
    /// </summary>
    public class MvcCell
    {
        /// <summary>
        /// Состояние клетки
        /// </summary>
        public SeaBattle.Data.State State;
    }
}