﻿using System.Collections.Generic;

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

        /// <summary>
        ///     Суммарная добавка площади на этаже
        /// </summary>
        public double Fine { get; set; }

        private Floor()
        {
            Number = 0;
            Flats = new List<Flat>();
            FlatsW1 = new List<Flat>();
            FlatsW2 = new List<Flat>();
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

        public static void AddFlat(Building building, Flat flat, int numberFloor)
        {
            building.Floors[numberFloor - 1].Flats.Add(flat);
        }

        //добавляем лестничную клетку на каждый этаж
        public static void AddEntryway(Building building, Flat entryway)
        {
            for (var numberFloor = 1; numberFloor <= building.CountFloor; ++numberFloor)
            {
                building.Floors[numberFloor - 1].Flats.Add(entryway);
            }
        }

    }
}
