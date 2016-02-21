using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Resettlement
{
	static class StartAndFinishProgram
	{
	    private static void Main()
	    {
	        //Запуск формы
	        Application.EnableVisualStyles();
	        Application.SetCompatibleTextRenderingDefault(false);
	        var ui = new UserInterface();
	        Application.Run(ui);
	    }
        const double Entryway = 2.7;
        const double WidthOfApartment = 5.7;
        const double Step = 0.3;
        
	    public static void Program(string[] l1, string[] l2, bool flag)
	    {


	        //flag = true fullSearch
			var enterDataOneRoomFlat = ReadFromFile.ReadFileOneRoom(l1);
			var enterDataTwoRoomFlat = ReadFromFile.ReadFileTwoRoom(l2);
			var squareOneRoomFlat = new double[enterDataOneRoomFlat.Count];
			var squareTwoRoomFlat = new double[enterDataTwoRoomFlat.Count];

			//запись в массив
			for (var i = 0; i < enterDataOneRoomFlat.Count; ++i)
			{
				squareOneRoomFlat[i] = enterDataOneRoomFlat[i];
			}
			for (var i = 0; i < enterDataTwoRoomFlat.Count; ++i)
			{
				squareTwoRoomFlat[i] = enterDataTwoRoomFlat[i];
			}

			var lengthOneRoomFlat = PreparationSquares.CalculateLengthOfFlat(squareOneRoomFlat, WidthOfApartment);
			var lengthTwoRoomFlat = PreparationSquares.CalculateLengthOfFlat(squareTwoRoomFlat, WidthOfApartment);
			var newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
			var newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
			var deltaOfOneRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthOneRoomFlat, newLengthOneRoomFlat);
			var deltaOfTwoRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthTwoRoomFlat, newLengthTwoRoomFlat);

            Console.WriteLine("Реализация для " + newLengthOneRoomFlat.Count * 2 + " квартир");
            Console.WriteLine();
 
            Console.WriteLine("Потери при округлении длин однокомнатных квартир до числа, кратного 0.3: " + deltaOfOneRoomFlat);
            Console.WriteLine("Потери при округлении длин двухкомнатных квартир до числа, кратного 0.3: " + deltaOfTwoRoomFlat);
			Console.WriteLine();
 /*
	        if (flag)
	        {
                if (lengthOneRoomFlat.Count >= 12 || lengthTwoRoomFlat.Count >= 12)
                {
                    MessageBox.Show("Для 12-ти и более вариантов используйте только жадный алгоритм");
                    Program(l1, l2, false);
                    return;
                }
	            var myStopWatch = new Stopwatch();
	            myStopWatch.Start();

	            var fullSearch = MethodeFullSearch.FullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, Step, Entryway);
	            myStopWatch.Stop();
	            Console.WriteLine("Время работы полного перебора");
	            Console.WriteLine((myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture) +
	                              " секунд");


	            Console.WriteLine("Итог полного перебора");
	            Console.WriteLine(string.Format("Минимальный штраф {0}", fullSearch[0]));
	            Console.WriteLine("Оптимальная расстановка однокомнатных квартир");
	            foreach (var i in (IEnumerable) fullSearch[1])
	            {
	                Console.Write(string.Format(" {0} ", i));
	            }
	            Console.WriteLine();
	            Console.WriteLine("Оптимальная расстановка двухкомнатных квартир");
	            foreach (var i in (IEnumerable) fullSearch[2])
	            {
	                Console.Write(string.Format(" {0} ", i));
	            }
	        }
 * */
	        //Todo Умножить на 5.7 чтобы получить площади квартир
			//6*2 квартир 0.02 секунды
			//8*2 квартир 0.052 секунды
			//10*2 квартир 26.576 секунд
			//12*2 квартир 5.5 часов и еще не закончился
	        if (flag == false)
	        {
	            var myStopWatchGreedy = new Stopwatch();
	            myStopWatchGreedy.Start();
	            var firstOneFlat = 0.0;
	            var currentTotalFine = 10000.0;
	            var minTotalFine = 100000.0;
	            int a = 0;
	            while (minTotalFine > currentTotalFine)
	            {
	                if (a > 0)
	                {
	                    minTotalFine = currentTotalFine;
	                }
	                a++;

	                var greedyAlhorithm = GreedyAlgorithmSection.GreedyMethode(newLengthOneRoomFlat, newLengthTwoRoomFlat,
	                    Step, Entryway, firstOneFlat);
	                firstOneFlat = (double) greedyAlhorithm[3];
	                currentTotalFine = (double) greedyAlhorithm[0];

	                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
	                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);

	                Console.WriteLine();
	                Console.WriteLine();
	                Console.WriteLine("Итог " + a + "-й итерации жадного алгоритма");
	                Console.WriteLine(string.Format("Штраф {0}", greedyAlhorithm[0]));
	                Console.WriteLine("Оптимальная расстановка однокомнатных квартир");
	                foreach (var i in (IEnumerable) greedyAlhorithm[1])
	                {
	                    Console.Write(string.Format(" {0} ", i));
	                }
	                Console.WriteLine();
	                Console.WriteLine("Оптимальная расстановка двухкомнатных квартир");
	                foreach (var i in (IEnumerable) greedyAlhorithm[2])
	                {
	                    Console.Write(string.Format(" {0} ", i));
	                }
	                //var f = Math.Round(s1 + 0.3*newLengthOneRoomFlat.Count - s - 1.8*newLengthOneRoomFlat.Count,2);
	            }
	            myStopWatchGreedy.Stop();
	            Console.WriteLine();
	            Console.WriteLine();
	            Console.WriteLine("Время работы жадного алгоритма");
	            Console.WriteLine((myStopWatchGreedy.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture) +
	                              " секунд");
	        }
//	        Console.ReadKey();
		}
	}
}
