using System.Collections.Generic;

namespace Resettlement
{
    public class DataPermutFullS
    {
        public List<double[]> ListVariantsFlat { get; private set; }
        public List<double[]> ListExceedFlat { get; private set; }

        public DataPermutFullS(List<double[]> listVariantsFlat, List<double[]> listExceedFlat)
        {
            ListVariantsFlat = listVariantsFlat;
            ListExceedFlat = listExceedFlat;
        }
    }
    
}
