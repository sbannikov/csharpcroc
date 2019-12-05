using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


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
        [Display(Name = "Наименование рецепта пиццы")]
        [Required()]
        [MaxLength(127)]
        public string Name { get; set; }

        /// <summary>
        /// Диаметр пиццы в см
        /// </summary>
        [Display(Name = "Диаметр пиццы в см")]
        [Range(1, 255)]
        public int Diameter { get; set; }

        /// <summary>
        /// Стоимость пиццы в рублях
        /// </summary>
        [Display(Name = "Стоимость пиццы в рублях")]
        [Range(0.0, double.MaxValue)]
        public double Price { get; set; }

        /// <summary>
        /// Масса пиццы в граммах
        /// </summary>
        [Range(1, double.MaxValue)]
        [Display(Name = "Масса пиццы в граммах")]
        public double Mass { get; set; }

        /// <summary>
        /// Актуальный рецепт
        /// true - мы выпекаем пиццу по этому рецепту
        /// false - рецепт является архивным и не используется в настоящее время
        /// </summary>
        [Display(Name = "Актуальный рецепт")]
        public bool Active { get; set; }

        /// <summary>
        /// Калорийность пиццы
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Сalorie { get; set; }
    }
}