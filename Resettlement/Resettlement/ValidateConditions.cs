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


        }
    }
}
