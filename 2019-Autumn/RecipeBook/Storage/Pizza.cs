using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBook.Storage
{
    /// <summary>
    /// Рецепт пиццы, сын сущности
    /// </summary>
    public class Pizza : Entity
    {
        /// <summary>
        /// Наименование рецепта пиццы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Диаметр пиццы в см
        /// </summary>
        public int Diameter { get; set; }

        /// <summary>
        /// Стоимость пиццы в рублях
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Масса пиццы в граммах
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Актуальный рецепт
        /// true - мы выпекаем пиццу по этому рецепту
        /// false - рецепт является архивным и не используется в настоящее время
        /// </summary>
        public bool Active { get; set; }
    }
}