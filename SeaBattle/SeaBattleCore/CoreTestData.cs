using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaBattle
{
    /// <summary>
    /// Массив данных для тестирования
    /// </summary>
    public class CoreTestData
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid ID { get; set; }
        [Range(0, 9)]
        [Required()]
        public int X1 { get; set; }
        [Range(0, 9)]
        [Required()]
        public int Y1 { get; set; }
        [Range(0, 9)]
        [Required()]
        public int X2 { get; set; }
        [Range(0, 9)]
        [Required()]
        public int Y2 { get; set; }
        /// <summary>
        /// Результат теста
        [Required()]
        public bool Result { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CoreTestData()
        {
            // Генерация нового уникального идентификатора
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// Конструктор со значениями
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="result"></param>
        public CoreTestData(int x1, int y1, int x2, int y2, bool result)
            : this()
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            Result = result;
        }

        /// <summary>
        /// Формирование данных для тестирования
        /// </summary>
        /// <returns></returns>
        public static List<CoreTestData> CheckNearData()
        {
            // Инициализация базы данных
            var db = new DB();
            // Чтение данных
            var list = db.Data.ToList();

            return list;
        }
    }
}
