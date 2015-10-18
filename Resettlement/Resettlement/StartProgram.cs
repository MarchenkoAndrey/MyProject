using System;
using System.Collections;

namespace Resettlement
{
	static class StartProgram
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

			var resultMethode = FullSearch.MethodeFullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway);

			Console.WriteLine();
			Console.WriteLine(string.Format("Минимальный штраф {0}", resultMethode[0]));
			//Console.WriteLine(resultMethode);
			Console.Write("Оптимальная расстановка однокомнатных квартир");
			foreach (var i in (IEnumerable) resultMethode[1])
			{
				Console.Write(string.Format(" {0} ",i));
			}
			Console.WriteLine();
			Console.Write("Оптимальная расстановка двухкомнатных квартир");
			foreach (var i in (IEnumerable)resultMethode[2])
			{
				Console.Write(string.Format(" {0} ", i));
			}
			//Todo Умножить на 5.7 чтобы получить площади квартир
			Console.ReadKey();
		}
	}
}
