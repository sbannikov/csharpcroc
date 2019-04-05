using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Database
{
    partial class SeaBattleEntities : IDatabase
    {
        /// <summary>
        /// Регистрация сеанса в базе данных
        /// </summary>
        public void Register()
        {
            // Имя компьютера
            string name = System.Environment.MachineName;
            // Текущая метка времени
            DateTime now = DateTime.Now;
            // Проверка на существование записи
            Sessions s = Sessions.Where(a => a.ComputerName == name).FirstOrDefault();

            // Альтернативный вариант синтаксиса - LINQ
            var q = from a in Sessions where a.ComputerName == name select a;
            Sessions s1 = (from a in Sessions where a.ComputerName == name select a).FirstOrDefault();

            // Проверка на существование записи
            if (s == null)
            {
                // Добавляем новую строчку
                //  Создание новой сущности
                s = new Sessions()
                {
                    ComputerName = name,
                    TimeStamp = now,
                    Description = string.Empty
                };
                // Добавление сущности в базу данных
                Sessions.Add(s);
            }
            else
            {
                // Обновление существующей записи
                s.TimeStamp = now;
            }
            // Запись изменений в базу данных
            SaveChanges();
        }
    }
}
