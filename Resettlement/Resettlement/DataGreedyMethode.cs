﻿using System.Collections.Generic;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class DataGreedyMethode
    {
        public double Step { get; set; }
        public double Entryway { get; set; }
        public double AddingA { get; private set; }
        public double AddingB { get; private set; }
        public int OptCountFlatOnFloor { get; private set; }

        public List<double> ListLenOneFlat;
        public List<double> ListLenTwoFlat;



        public DataGreedyMethode(List<double> list1, List<double> list2, int optCountFlat)
        {
            ListLenOneFlat = list1;
            ListLenTwoFlat = list2;
            Step = Constraints.ThickWallsWidth;
            Entryway = Constraints.EntrywayLength;
            AddingA = 3*Step + Entryway;
            AddingB = 2*Step;
            OptCountFlatOnFloor = optCountFlat;
        }
    }
}