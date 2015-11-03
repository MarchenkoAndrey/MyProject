using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace Resettlement
{
	static class StartAndFinishProgram
	{
		static void Main()
		{		
			const double entryway = 2.7;
			const double widthOfApartment = 5.7;
			const double step = 0.3;
			var enterDataOneRoomFlat = ReadFromFile.ReadFileOneRoom();
			var enterDataTwoRoomFlat = ReadFromFile.ReadFileTwoRoom();
			var squareOneRoomFlat = new double[enterDataOneRoomFlat.Count];
			var twoRoom = new double[enterDataTwoRoomFlat.Count];

			//запись в массив
			for (var i = 0; i < enterDataOneRoomFlat.Count; ++i)
			{
				squareOneRoomFlat[i] = enterDataOneRoomFlat[i];
			}
			for (var i = 0; i < enterDataTwoRoomFlat.Count; ++i)
			{
				twoRoom[i] = enterDataTwoRoomFlat[i];
			}

			var lengthOneRoomFlat = PreparationSquares.CalculateLengthOfFlat(squareOneRoomFlat, widthOfApartment);
			var lengthTwoRoomFlat = PreparationSquares.CalculateLengthOfFlat(twoRoom, widthOfApartment);
			var newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
			var newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
			var deltaOfOneRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthOneRoomFlat, newLengthOneRoomFlat);
			var deltaOfTwoRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthTwoRoomFlat, newLengthTwoRoomFlat);

			Console.WriteLine("Реализация для " +newLengthOneRoomFlat.Count*2 + " квартир");
			Console.WriteLine();

//            var myStopWatch = new Stopwatch();
//            myStopWatch.Start();
//
//            var fullSearch = MethodeFullSearch.FullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway);
//            myStopWatch.Stop();
//            Console.WriteLine("Время работы полного перебора");
//            Console.WriteLine((myStopWatch.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) + " секунд");
//
//
//            Console.WriteLine("Итог полного перебора");
//            Console.WriteLine(string.Format("Минимальный штраф {0}", fullSearch[0]));
//            Console.WriteLine("Оптимальная расстановка однокомнатных квартир");
//            foreach (var i in (IEnumerable)fullSearch[1])
//            {
//                Console.Write(string.Format(" {0} ", i));
//            }
//            Console.WriteLine();
//            Console.WriteLine("Оптимальная расстановка двухкомнатных квартир");
//            foreach (var i in (IEnumerable)fullSearch[2])
//            {
//                Console.Write(string.Format(" {0} ", i));
//            }
			//Todo Умножить на 5.7 чтобы получить площади квартир
			//6*2 квартир 0.02 секунды
			//8*2 квартир 0.052 секунды
			//10*2 квартир 26.576 секунд
			//12*2 квартир 5.5 часов и еще не закончился


			var myStopWatchGreedy = new Stopwatch();
			myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var currentTotalFine=10000.0;
            var minTotalFine = 100000.0;
            int a = 0;
            while(minTotalFine>currentTotalFine)
            {
                if (a > 0) { minTotalFine = currentTotalFine; }
                a++;
                
			    var greedyAlhorithm = GreedyAlcorithmSection.GreedyMethode(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway,firstOneFlat);
                firstOneFlat = (double)greedyAlhorithm[3];
                currentTotalFine = (double)greedyAlhorithm[0];
                
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
                Console.WriteLine(); Console.WriteLine();
      
			    Console.WriteLine("Итог "+ a + "-й итерации жадного алгоритма");
			    Console.WriteLine(string.Format("Штраф {0}", greedyAlhorithm[0]));
			    Console.WriteLine("Оптимальная расстановка однокомнатных квартир");
			    foreach (var i in (IEnumerable)greedyAlhorithm[1])
			    {
				    Console.Write(string.Format(" {0} ", i));
			    }
			    Console.WriteLine();
			    Console.WriteLine("Оптимальная расстановка двухкомнатных квартир");
			    foreach (var i in (IEnumerable)greedyAlhorithm[2])
			    {
				    Console.Write(string.Format(" {0} ", i));
			    }
                
            }
            myStopWatchGreedy.Stop();
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Время работы жадного алгоритма");
            Console.WriteLine((myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) + " секунд");
          
			Console.ReadKey();
		}
	}
}
