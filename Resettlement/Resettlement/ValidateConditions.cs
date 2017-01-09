using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class ValidateConditions
    {
        public static void Validate(InputDataAlg data, bool isHeuristicAlgoritm) 
        {
            if (data.CountFloor == 0)
            MessageBox.Show(ErrorsText.NotSelectedFloor);

            if (isHeuristicAlgoritm) return;
            if (data.ListLenOneFlat.Count/data.CountFloor >= 12 && data.ListLenTwoFlat.Count/data.CountFloor >= 12)
                MessageBox.Show(ErrorsText.NotSixContaiters);
        }
    }
}
