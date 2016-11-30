﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComputationMethods
{
    public static class ReadFromFileAndRecordingInputDataInList
	{
		public static List<double> ReadFile(string fileName)
		{
            var arrayData = File.ReadAllLines(Path.Combine(@"D:\MyProject\MyProject\Resettlement\ComputationMethods\Examples", fileName));
            var enterData = RecordingInputDataInList(arrayData);
		    return enterData;
		}

	    private static List<double> RecordingInputDataInList(string[] inputData)
        {
            var enterData = new List<double>();
            var inputArgs =
                inputData[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            for (var j = 0; j < inputArgs.Count(); j++)
            {
                enterData.Add(inputArgs[j]);
            }
            return enterData;
        }
	}
}