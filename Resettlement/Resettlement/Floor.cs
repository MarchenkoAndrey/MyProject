using System.Collections.Generic;

namespace Resettlement
{
    public class Floor
    {
        public int Number { get; set; }
        /// <summary>
        ///     Список квартир в нижней части секции
        /// </summary>
        public List<Flat> FlatsW1 { get; set; }

        /// <summary>
        ///     Список квартир в верхней части секции
        /// </summary>
        public List<Flat> FlatsW2 { get; set; }

        public double Fine { get; set; }
    }
}
