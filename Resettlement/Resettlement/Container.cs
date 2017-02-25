using System.Collections.Generic;

namespace Resettlement
{
    public class Container
    {
        public double OriginA1 { get; set; }

        public double OriginA2 { get; set; }
        public double OriginB1 { get; set; }
        public double OriginB2 { get; set; }

        public double A1 { get; set; }
        public double A2 { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }

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

        public Container(DataGreedyMethode data)
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
