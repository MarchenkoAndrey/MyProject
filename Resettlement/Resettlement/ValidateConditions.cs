using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    static class ValidateConditions
    {
        public static void Validate(DataAlgorithm data)
        {
            //Не указан этаж
            if (data.CountFloor == 0)
            MessageBox.Show(ErrorsText.NotSelectedFloor);


        }
    }
}
