﻿using System.Collections.Generic;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    //Todo не подходит для кастом версии, добавить значения
    public class DataMethode
    {
        public double WallsWidth { get; private set; }
        private double Entryway { get; set; }
        public double AddingA { get; private set; }
        public double AddingB { get; private set; }
        public int OptCountFlatOnFloor { get; private set; }
        public readonly List<double> ListLenOneFlat;
        public readonly List<double> ListLenTwoFlat;

        //Extended field
        public double EntrywayPlusCorridor { get; private set; }

        public DataMethode(List<double> list1, List<double> list2, int optCountFlat)
        {
            ListLenOneFlat = list1;
            ListLenTwoFlat = list2;
            WallsWidth = Constraints.WallsWidth;
            Entryway = Constraints.EntrywayLength;
            AddingA = 3*WallsWidth + Entryway;
            AddingB = 2*WallsWidth;
            OptCountFlatOnFloor = optCountFlat;
            EntrywayPlusCorridor = 4.5;
        }
    }
}