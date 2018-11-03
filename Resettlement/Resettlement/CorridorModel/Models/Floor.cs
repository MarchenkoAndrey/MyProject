using System.Collections.Generic;

namespace Resettlement.CorridorModel.Models
{
    public class Floor
    {
        /// <summary>
        ///     Номер этажа
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        ///     Список квартир
        /// </summary>
        public List<Flat> Flats { get; set; }
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

        public Floor()
        {
            Number = 0;
            Flats = new List<Flat>();
            FlatsW1 = new List<Flat>();
            FlatsW2 = new List<Flat>();
            SumLivingSquare = 0;
            Fine = 0;
        }
        public static List<Floor> CreateFloors(int countFloor)
        {
            var floors = new List<Floor>();
            for (var i = 0; i < countFloor; i++)
            {
                floors.Add(new Floor { Number = i + 1 });
            }
            return floors;
        }
    }
}
