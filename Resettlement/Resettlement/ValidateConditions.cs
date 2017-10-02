using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class ValidateConditions
    {
        public static void Validate(InputDataAlg data, bool isHeuristicAlgoritm) 
        {
            //Выберите этаж
            if (data.CountFloor == 0)
            MessageBox.Show(ErrorsText.NotSelectedFloor);

            //Отсечка, следующие проверки только для полного перебора
            if (isHeuristicAlgoritm) return;

            //Полный перебор невозможен для 6+ контейнеров
            if (data.ListLenOneFlat.Count/data.CountFloor >= 12 && data.ListLenTwoFlat.Count/data.CountFloor >= 12)
                MessageBox.Show(ErrorsText.NotSixContaiters);
        }
    }
}
