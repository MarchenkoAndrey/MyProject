using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Resettlement
{
    public static class ReadFromFile
	{
		public static List<double> ReadFileOneRoom(string[] inputData)
		{
            string[] arrayData = inputData[0] == "" ? File.ReadAllLines("OneRoom20.txt") : inputData;
		    var enterData = new List<double>();
				var inputArgs =
					arrayData[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
				for (var j = 0; j < inputArgs.Count(); j++)
				{
					enterData.Add(inputArgs[j]);
				}
			return enterData;
		}
		public static List<double> ReadFileTwoRoom(string[] inputData)
		{
            string[] arrayData = inputData[0] == "" ? File.ReadAllLines("TwoRoom20.txt") : inputData;
			var enterData = new List<double>();
				var inputArgs =
					arrayData[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
				for (var j = 0; j < inputArgs.Count(); j++)
				{
					enterData.Add(inputArgs[j]);
				}
			return enterData;
		}
	}
}
