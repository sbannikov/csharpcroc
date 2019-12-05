using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBook.Storage
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Entity()
        {
            ID = Guid.NewGuid();
        }
    }
}