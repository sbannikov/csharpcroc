using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Сущность, хранящаяся в базе данных
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Уникальный идентификатор записи
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
