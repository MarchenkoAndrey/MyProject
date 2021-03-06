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
		    return
		        RecordingInputDataInList(
		            File.ReadAllLines(Path.Combine(@"D:\MyProject\MyProject\Resettlement\ComputationMethods\TestExamples",
		                fileName)));
		}

	    private static List<double> RecordingInputDataInList(IReadOnlyList<string> inputData)
	    {
	        return
	            inputData[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
	    }
	}
}