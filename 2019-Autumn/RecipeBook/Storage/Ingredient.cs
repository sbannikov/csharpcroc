using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeBook.Storage
{
    /// <summary>
    /// Ингредиент
    /// </summary>
    public class Ingredient : Entity
    {
        /// <summary>
        /// Наименование ингредиента
        /// </summary>
        [Display(Name = "Наименование ингредиента")]
        [Required()]
        [MaxLength(127)]
        public string Name { get; set; }
    }
}