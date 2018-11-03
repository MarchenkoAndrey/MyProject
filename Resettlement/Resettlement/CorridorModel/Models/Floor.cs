using System.Collections.Generic;
using Resettlement.CorridorModel;

namespace Resettlement
{
    public class Floor
    {
        /// <summary>
        ///     Номер этажа
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        ///     Список квартир в нижней части секции
        /// </summary>
        public List<Flat> FlatsW1 { get; set; }

        /// <summary>
        ///     Список квартир в верхней части секции
        /// </summary>
        public List<Flat> FlatsW2 { get; set; }

        public double SumLivingSquare { get; set; }

        /// <summary>
        ///     Суммарная добавка площади на этаже
        /// </summary>
        public double Fine { get; set; }
    }
}
