﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle.Data
{
    /// <summary>
    /// Поле игры
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Массив кораблей
        /// </summary>
        public Ship[] Ships;

        /// <summary>
        /// Добавление однопалубного корабля
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public void AddShip1(int x, int y)
        {
            // Создание нового корабля
            var ship = new Ship(x, y);
            // Проверка на существование массива
            if (Ships == null)
            {
                // Создание массива из одного элемента
                Ships = new Ship[1] { ship };
            }
            else
            {
                // Увеличение массива на одну ячейку
                Array.Resize(ref Ships, Ships.Length + 1);
                // Заполнение вновь созданной ячейки
                Ships[Ships.Length - 1] = ship;
            }
        }

        /// <summary>
        /// Добавление двухпалубного корабля
        /// </summary>
        /// <param name="cell">Первая клетка</param>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public void AddShip2(Cell cell, int x, int y)
        {
            // Создание нового корабля
            var ship = new Ship(cell, x, y);
            // Проверка на существование массива
            if (Ships == null)
            {
                // Создание массива из одного элемента
                Ships = new Ship[1] { ship };
            }
            else
            {
                // Увеличение массива на одну ячейку
                Array.Resize(ref Ships, Ships.Length + 1);
                // Заполнение вновь созданной ячейки
                Ships[Ships.Length - 1] = ship;
            }
        }

        /// <summary>
        /// Проверка доступности клетки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <returns></returns>
        public bool CheckCellAvail(int x, int y)
        {
            if (Ships != null)
            {
                foreach (Ship ship in Ships)
                {
                    if (!ship.CheckCellAvail(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Проверка состояния клетки
        /// </summary>
        /// <param name="cell">Клетка</param>
        /// <returns></returns>
        public State CellState(Cell cell)
        {
            if (Ships != null)
            {
                foreach (Ship ship in Ships)
                {
                    State s = ship.CellState(cell);
                    if (s != State.None)
                    {
                        return s;
                    }
                }
            }
            // Промах
            return State.None;
        }
    }
}
