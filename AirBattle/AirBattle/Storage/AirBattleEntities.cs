using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle.Storage
{
    /// <summary>
    /// База данных Entity Framework Database First
    /// </summary>
    partial class AirBattleEntities : IDatabase
    {
        /// <summary>
        /// Регистрация приложения в списке активных приложений
        /// </summary>
        public void Register()
        {
            // Текущая метка времени
            DateTime now = DateTime.Now;
            // Имя моего компьютера 
            string name = Environment.MachineName;
            // Проверка на существование записи - вариант 1
            Session s1 = Session.Where(a => a.ComputerName == name).FirstOrDefault();
            // Проверка на существование записи - вариант 2 (LINQ)
            Session s2 = (from a in Session where a.ComputerName == name select a).FirstOrDefault();
            // Если запись не существует
            if (s1 == null)
            {
                // Создание нового объекта
                s1 = new Session()
                {
                    ComputerName = name,
                    TimeStamp = now
                };
                // Добавление объекта в таблицу в памяти
                Session.Add(s1);
            }
            else // Запись была найдена
            {
                s1.TimeStamp = now;
            }
            // Сохранение в базу данных
            SaveChanges();
        }
    }
}
