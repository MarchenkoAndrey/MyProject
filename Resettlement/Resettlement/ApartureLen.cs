using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public struct OriginDataContainer
    {
        public double OldA1 { get; set; }
        public double OldA2 { get; set; }
        public double OldB1 { get; set; }
        public double OldB2 { get; set; }
    }

    public class ApartureLen
    {
        public OriginDataContainer OriginDataContainer;
        public double A1 { get; private set; }
        public double A2 { get; private set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        public double ExtraSquare { get; set; }
        public double Fine { get; set; }


        public ApartureLen(double a1, double a2, double b1, double b2)
        {
            A1 = a1;
            A2 = a2;
            B1 = b1;
            B2 = b2;
            OriginDataContainer = new OriginDataContainer
            {
                OldA1 = a1,
                OldA2 = a2,
                OldB1 = b1,
                OldB2 = b2
            };
            Fine = 0;
            ExtraSquare = 0;
        }

        public ApartureLen(double maxValue)
        {
            A1 = 0;
            A2 = 0;
            B1 = 0;
            B2 = 0;
            ExtraSquare = maxValue;
            Fine = 0;
            OriginDataContainer = new OriginDataContainer
            {
                OldA1 = 0,
                OldA2 = 0,
                OldB1 = 0,
                OldB2 = 0
            };
        }
    }

    public static class CompALen
    {
        public static ApartureLen OptimalPackContainer(double choiceOneFlat, double t, double i, double j, double wallsWidth)
        {
            var resultPackSect =
                CalculateOptimalPackContainer(
                    new ApartureLen(choiceOneFlat, t, i,
                        j), wallsWidth);

            var resultPackSectRev =
                CalculateOptimalPackContainer(
                    new ApartureLen(choiceOneFlat, t, j,
                        i), wallsWidth);

            return CalculateOptimalContainerWithMinFine(new List<ApartureLen>{resultPackSect, resultPackSectRev});
        }

        private static ApartureLen CalculateOptimalContainerWithMinFine(List<ApartureLen> containers)
        {
            //Считается и добавка ExtraSquare
            foreach (var container in containers)
            {
                container.Fine = Math.Abs(Math.Round(
                container.B1 + container.B2 + Constraints.AddingB -
                (container.A1 + container.A2 + Constraints.AddingA)
                + container.ExtraSquare, 1));
            }
            return containers
                .OrderBy(a=>a.Fine)
                .Take(1).First();
        }

        public static ApartureLen CalculateOptimalPackContainer(ApartureLen data, double step)
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
            return data;
        }
    }
}
