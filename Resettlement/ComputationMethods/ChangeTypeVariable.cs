﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationMethods
{
    public static class ChangeTypeVariable
    {
        public static double[] ChangeListIntoArray(List<double> inputList)
        {
            var resultArray = new double[inputList.Count];
            for (var i = 0; i < inputList.Count; ++i)
            {
                resultArray[i] = inputList[i];
            }
            return resultArray;
        }
    }
}