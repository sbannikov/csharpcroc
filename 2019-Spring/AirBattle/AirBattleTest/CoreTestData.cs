using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SeaBattleTest
{
    public class CoreTestData
    {
        /// <summary>
        /// Уникальный ключ записи
        /// </summary>
        public Guid ID { get; set; }

        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public bool Result { get; set; }

        /// <summary>
        /// Описание данных
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// Формирование данных для тестирования
        /// </summary>
        /// <returns></returns>
        public static List<CoreTestData> CheckCellNearData()
        {
            var db = new DB();
            return db.CoreTestData.ToList();
        }
    }
}
