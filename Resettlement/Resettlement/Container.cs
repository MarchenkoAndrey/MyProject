using System;

namespace Resettlement
{
    public class Container
    {
        public double A1;
        public double A2;
        public double B1;
        public double B2;
        public double Fine;
        public double AbsFine;
        public double LenA;
        public double LenB;
        private int ParentId { get; set;}

        //Заполнять здесь
        public Container(InputDataAlg data)
        {
            AbsFine = Math.Abs(Fine);
            LenA = A1 + A2 + data.AddingA;
            LenB = B1 + B2 + data.AddingB;
        }

        public Container()
        {

        }
    }
}
