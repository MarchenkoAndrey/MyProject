﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Resettlement
{
	static class ReadFromFile
	{
		public static List<double> ReadFileOneRoom(string[] l)
		{
		    string[] str = l[0] == "" ? File.ReadAllLines("OneRoom10.txt") : l;
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
		public static List<double> ReadFileTwoRoom(string[] l)
		{
		    string[] str = l[0] == "" ? File.ReadAllLines("TwoRoom10.txt") : l;
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
