using System.Collections.Generic;

namespace Resettlement
{
    public class Container
    {
        public DataContainer OriginDataContainer;
        public DataContainer DataContainer;
        public double Fine { get; set; }
        public List<double> ExceedListOneFlat { get; set; }
        public List<double> ExceedListTwoFlat { get; set; }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public double FineChain { get; set; }

        public Container(Container data)
        {
            Id = 0;
            ParentId = null;
            Fine = 0.0;
            FineChain = data.FineChain;
            ExceedListOneFlat = data.ExceedListOneFlat;
            ExceedListTwoFlat = data.ExceedListTwoFlat;
        }
        //Первый контейнер ?
        public Container(DataMethode data)
        {
            Id = 0;
            ParentId = null;
            Fine = 0.0;
            FineChain = 0.0;
            ExceedListOneFlat = data.ListLenOneFlat;
            ExceedListTwoFlat = data.ListLenTwoFlat;
        }
    }
}
