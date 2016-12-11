using System.Collections.Generic;

namespace Resettlement
{
    public class TempData
    {
        public List<double> CurrentResultListFlat { get; set; }
        public double CurrentFineFlat;

        public TempData()
        {
            CurrentFineFlat = 0.0;
            CurrentResultListFlat = new List<double>();
        }
    }
}
