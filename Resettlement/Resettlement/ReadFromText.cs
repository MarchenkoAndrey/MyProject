using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Resettlement
{
	static class ReadFromFile
	{
		public static List<double> ReadFileOneRoom()
		{
			var str = File.ReadAllLines("OneRoom.txt"); // построчно
			var enterData = new List<double>();
			if (str.Length != 0)
			{
				var inputArgs =
					str[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
				for (var j = 0; j < inputArgs.Count(); j++)
				{
					enterData.Add(inputArgs[j]);
				}
			}
			return enterData;
		}
		public static List<double> ReadFileTwoRoom()
		{
			var str = File.ReadAllLines("TwoRoom.txt"); // построчно
			var enterData = new List<double>();
			if (str.Length != 0)
			{
				var inputArgs =
					str[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
				for (var j = 0; j < inputArgs.Count(); j++)
				{
					enterData.Add(inputArgs[j]);
				}
			}
			return enterData;
		}
	}
}
