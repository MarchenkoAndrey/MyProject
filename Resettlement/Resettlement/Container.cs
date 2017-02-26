using System.Collections.Generic;

namespace Resettlement
{
    public struct DataContainer
    {
        public double A1 { get; set; }
        public double A2 { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }

        private bool Equals(DataContainer other)
        {
            return A1.Equals(other.A1) && A2.Equals(other.A2) && B1.Equals(other.B1) && B2.Equals(other.B2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DataContainer && Equals((DataContainer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = A1.GetHashCode();
                hashCode = (hashCode*397) ^ A2.GetHashCode();
                hashCode = (hashCode*397) ^ B1.GetHashCode();
                hashCode = (hashCode*397) ^ B2.GetHashCode();
                return hashCode;
            }
        }
    }

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
