using System;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class ApartureLen
    {
        //Todo переписать, убрать дубликаты. Подписать каждый конструктор
        public readonly double OldA1;
        public readonly double OldA2;
        public readonly double OldB1;
        public readonly double OldB2;

        public readonly double A1;
        public readonly double A2;
        public double B1;
        public double B2;
        public double ExtraSquare;

        public ApartureLen(double a1, double a2, double b1, double b2)
        {
            A1 = a1;
            A2 = a2;
            B1 = b1;
            B2 = b2;
            OldA1 = a1;
            OldA2 = a2;
            OldB1 = b1;
            OldB2 = b2;
            ExtraSquare = 0;
        }

        public ApartureLen(double a1, double a2, double b1, double b2, double extraSquare)
        {
            A1 = a1;
            A2 = a2;
            B1 = b1;
            B2 = b2;
            ExtraSquare = extraSquare;
            OldA1 = a1;
            OldA2 = a2;
            OldB1 = b1;
            OldB2 = b2;
        }

        public ApartureLen(double maxValue)
        {
            A1 = 0;
            A2 = 0;
            B1 = 0;
            B2 = 0;
            ExtraSquare = maxValue;
            OldA1 = 0;
            OldA2 = 0;
            OldB1 = 0;
            OldB2 = 0;
        }
    }

    public static class CompALen
    {
        public static ApartureLen Method(ApartureLen data, double step)
        {
            if (data.B1 - data.A1 < Constraints.ApartureLength)
            {
                var tempFine1 = Math.Round(Constraints.ApartureLength - (data.B1 - data.A1), 2);
                if (tempFine1 <= step)
                {
                    data.B1 += Math.Round(step, 1);
                    data.ExtraSquare += Math.Round(step, 1);
                }
                else
                {
                    data.B1 += Math.Round(Math.Ceiling(tempFine1 / step) * step, 1);
                    data.ExtraSquare += Math.Round(Math.Ceiling(tempFine1 / step) * step, 1);
                }
            }
            if (data.B2 - data.A2 < Constraints.ApartureLength)
            {
                var tempFine2 = Math.Round(Constraints.ApartureLength - (data.B2 - data.A2), 2);
                if (tempFine2 <= step)
                {
                    data.B2 += Math.Round(step, 1);
                    data.ExtraSquare += Math.Round(step, 1);
                }
                else
                {
                    data.B2 += Math.Round(Math.Ceiling(tempFine2 / step) * step, 1);
                    data.ExtraSquare += Math.Round(Math.Ceiling(tempFine2 / step) * step, 1);
                }
            }
            return new ApartureLen(data.A1, data.A2, data.B1, data.B2, data.ExtraSquare);
        }
    }
}
