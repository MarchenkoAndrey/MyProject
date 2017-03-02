namespace Resettlement
{
    public struct DataContainer
    {
        public double A1 { get; set; }
        public double A2 { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        //вынести сюда fine со своим хеш-множителем?

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
}
