using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class ApartureLen
    {
        public DataContainer OriginDataContainer;
        public DataContainer DataContainer;
        public double ExtraSquare { get; set; }
        public double Fine { get; set; }


        public ApartureLen(double a1, double a2, double b1, double b2)
        {
            DataContainer = new DataContainer
            {
                A1 = a1,
                A2 = a2,
                B1 = b1,
                B2 = b2
            };
            OriginDataContainer = new DataContainer
            {
                A1 = a1,
                A2 = a2,
                B1 = b1,
                B2 = b2
            };
            Fine = 0;
            ExtraSquare = 0;
        }

        public ApartureLen(double maxValue)
        {
            DataContainer = new DataContainer
            {
                A1 = 0,
                A2 = 0,
                B1 = 0,
                B2 = 0
            };
            OriginDataContainer = new DataContainer
            {
                A1 = 0,
                A2 = 0,
                B1 = 0,
                B2 = 0
            };
            ExtraSquare = maxValue;
            Fine = 0;
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
                container.DataContainer.B1 + container.DataContainer.B2 + Constraints.AddingB -
                (container.DataContainer.A1 + container.DataContainer.A2 + Constraints.AddingA)
                + container.ExtraSquare, 1));
            }
            return containers
                .OrderBy(a=>a.Fine)
                .Take(1).First();
        }

        public static ApartureLen CalculateOptimalPackContainer(ApartureLen data, double step)
        {

            if (data.DataContainer.B1 - data.DataContainer.A1 < Constraints.ApartureLength)
            {
                var tempFine1 = Math.Round(Constraints.ApartureLength - (data.DataContainer.B1 - data.DataContainer.A1), 2);
                if (tempFine1 <= step)
                {
                    data.DataContainer.B1 += Math.Round(step, 1);
                    data.ExtraSquare += Math.Round(step, 1);
                }
                else
                {
                    data.DataContainer.B1 += Math.Round(Math.Ceiling(tempFine1 / step) * step, 1);
                    data.ExtraSquare += Math.Round(Math.Ceiling(tempFine1 / step) * step, 1);
                }
            }
            if (data.DataContainer.B2 - data.DataContainer.A2 < Constraints.ApartureLength)
            {
                var tempFine2 = Math.Round(Constraints.ApartureLength - (data.DataContainer.B2 - data.DataContainer.A2), 2);
                if (tempFine2 <= step)
                {
                    data.DataContainer.B2 += Math.Round(step, 1);
                    data.ExtraSquare += Math.Round(step, 1);
                }
                else
                {
                    data.DataContainer.B2 += Math.Round(Math.Ceiling(tempFine2 / step) * step, 1);
                    data.ExtraSquare += Math.Round(Math.Ceiling(tempFine2 / step) * step, 1);
                }
            }
            return data;
        }
    }
}
