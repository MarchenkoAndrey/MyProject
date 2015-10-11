using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
	static class StartProgram
	{
		static void Main()
		{
			
			const double thicknessChiefWall = 0.15;
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

			var l = 23.04;
			l = Math.Ceiling(l);

			var lengthOneRoomFlat = PreparationSquares.CalculateLengthOfFlat(squareOneRoomFlat, widthOfApartment);
			var lengthTwoRoomFlat = PreparationSquares.CalculateLengthOfFlat(twoRoom, widthOfApartment);
			var newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
			var newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
			var deltaOfOneRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthOneRoomFlat, newLengthOneRoomFlat);
			var deltaOfTwoRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthTwoRoomFlat, newLengthTwoRoomFlat);

			var resultMethode = FullSearch.MethodeFullSearch(enterDataOneRoomFlat, enterDataTwoRoomFlat, step, widthOfApartment, entryway);
		}
	}
}
