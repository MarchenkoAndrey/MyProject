using System;
using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    static class ValidateConditions
    {
        public static void Validate(InputDataAlg data)
        {
            //Не указан этаж
            if (data.CountFloor == 0)
            MessageBox.Show(ErrorsText.NotSelectedFloor);

            if (data.ListLenOneFlat.Count / data.CountFloor >= 12 && data.ListLenTwoFlat.Count / data.CountFloor >= 12)
                MessageBox.Show(ErrorsText.NotSixContaiters);

//            if ((Math.Abs(data.ListLenOneFlat.Count - data.ListLenTwoFlat.Count) >= 3 ||
//                 (Math.Abs(data.ListLenOneFlat.Count - data.ListLenTwoFlat.Count) == 2 &&
//                  data.ListLenOneFlat.Count%2 != 0)) && data.CountFloor == 1)
//                MessageBox.Show(ErrorsText.TooManyContainers);

        }
    }
}
