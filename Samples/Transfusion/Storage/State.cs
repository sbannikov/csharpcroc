using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Состояние
    /// </summary>
    public class State : Entity
    {
        /// <summary>
        /// Тип состояния
        /// </summary>
        [Display(Name = "Тип состояния")]
        public virtual StateType SType { get; set; }
        /// <summary>
        /// Идентификатор головоломки
        /// </summary>
        public Guid PuzzleID { get; set; }
        /// <summary>
        /// Головоломка
        /// </summary>
        [ForeignKey("PuzzleID")]
        public virtual Puzzle Puzzle { get; set; }

        /// <summary>
        /// Состояния сосудов
        /// </summary>
        public virtual ICollection<StateOfVessel> StateOfVessels { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public State() { }

        /// <summary>
        /// Построение состояния после переливания
        /// </summary>
        /// <param name="move"></param>
        public static State NextState(Move move)
        {
            // Проверка на наличие состояния 
            if (move.ToState != null)
            {
                return move.ToState;
            }

            // Создание нового состояния
            var state = new State()
            {
                PuzzleID = move.FromState.PuzzleID,
                SType = StateType.Intermediate,
                StateOfVessels = new List<StateOfVessel>() // Создание списка 
            };

            // Сколько налито в сосуде, из которого мы переливаем
            int v1 = move.FromState.StateOfVessels.First(a => a.VesselID == move.FromVessel.ID).Value.Value;
            // Сколько свободного места в сосуде, куда мы переливаем
            int v2 = move.FromState.StateOfVessels.First(a => a.VesselID == move.ToVessel.ID).Free;
            // Определение переливаемого объема
            int v = Math.Min(v1, v2);

            // Построение списка состояния сосудов
            foreach (var sov in move.FromState.StateOfVessels)
            {
                // Копирование исходного состояния
                var newSov = new StateOfVessel()
                {
                    State = state,
                    VesselID = sov.VesselID
                };
                if (sov.VesselID == move.FromVessel.ID)
                {
                    // Отливаем от сосуда
                    newSov.Value = sov.Value - v;
                }
                else if (sov.VesselID == move.ToVessel.ID)
                {
                    // Доливаем в сосуд
                    newSov.Value = sov.Value + v;
                }
                else
                {
                    // Состояние сосуда не изменилось
                    newSov.Value = sov.Value;
                }
                // Добавление объекта в состояние
                state.StateOfVessels.Add(newSov);
            }
            // Новое состояние
            return state;
        }

        /// <summary>
        /// Сравнение объектов на равенство
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator ==(State s1, State s2)
        {
            // Считаем, что в данном случае null равен null
            if ((s1 is null) && (s2 is null))
            {
                return true;
            }
            // Если какой-либо из объектов null, но только один
            if ((s1 is null) || (s2 is null))
            {
                return false;
            }
            // Сравнение длин векторов состояний
            if (s1.StateOfVessels.Count != s2.StateOfVessels.Count)
            {
                return false;
            }
            // Сравнение объектов на равенство
            foreach (var sov1 in s1.StateOfVessels)
            {
                var sov2 = s2.StateOfVessels.FirstOrDefault(a => a.VesselID == sov1.VesselID);
                if (sov2 is null)
                {
                    return false; // Нет подходящего объекта
                }
                // Сравниванием два числа только если они оба заданы
                if (sov1.Value.HasValue && sov2.Value.HasValue)
                    if (sov1.Value != sov2.Value)
                    {
                        {
                            return false; // уровень жидкости в этом сосуде не равен
                        }
                    }
            }
            // Объекты равны!
            return true;
        }

        /// <summary>
        /// Сравнение на неравенство
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator !=(State s1, State s2)
        {
            return !(s1 == s2);
        }

        /// <summary>
        /// Сравнение объектов на равенство
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            return this == (State)obj;
        }
    }
}
