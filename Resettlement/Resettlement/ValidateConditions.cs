using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class ValidateConditions
    {
        public static void Validate(InputSectionDataAlg sectionData, bool isHeuristicAlgoritm) 
        {
            //Выберите этаж
            if (sectionData.CountFloor == 0)
            MessageBox.Show(MessagesText.NotSelectedFloor);

            //Отсечка, следующие проверки только для полного перебора
            if (isHeuristicAlgoritm) return;

            //Полный перебор невозможен для 6+ контейнеров
            if (sectionData.ListLenOneFlat.Count/sectionData.CountFloor >= 12 && sectionData.ListLenTwoFlat.Count/sectionData.CountFloor >= 12)
                MessageBox.Show(MessagesText.NotSixContaiters);
        }
    }
}
