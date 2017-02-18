using System;
using System.Collections.Generic;

namespace Resettlement
{
    public class ContainerTot
    {
        public List<Container> Containers { get; set; }
    }

    static class DynamicMethodeSect
    {
        public static List<Container> DynamicMethode(DataGreedyMethode data)
        {
            var resultDymMethode = new ContainerTot();
            var counter = data.OptCountFlatOnFloor;
            var container = new Container();
            //resultDymMethode.Containers.Add(container);
            while (counter>0)
            {
                var sortedListOneFlat = new List<double>(data.ListLenOneFlat);
                var choiceOneFlat = data.ListLenOneFlat[data.ListLenOneFlat.Count / 2];
                sortedListOneFlat.Remove(choiceOneFlat);
                var fine = double.MaxValue;
                

                
                container.A1 = choiceOneFlat;
//                container[1].A1 = choiceOneFlat;
//                container[2].A1 = choiceOneFlat;
                var arraySortedTwoApartments = data.ListLenTwoFlat.ToArray();

                for (var i = 0; i < data.ListLenTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < data.ListLenTwoFlat.Count; ++j)
                    {
                        foreach (var t in sortedListOneFlat)
                        {
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments,
                                currentMassiv = new double[arraySortedTwoApartments.Length],
                                arraySortedTwoApartments.Length);

                            var resultPackSectRev =
                                CompALen.Method(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[j],
                                        currentMassiv[i]), data.Step);
                                    
                            var resultPackSect =
                                CompALen.Method(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[i],
                                        currentMassiv[j]), data.Step);

                            var currentFineReverse =
                                Math.Abs(Math.Round(
                                    resultPackSectRev.B1 + resultPackSectRev.B2 + data.AddingB -
                                    (resultPackSectRev.A1 + resultPackSectRev.A2 + data.AddingA)
                                    + resultPackSectRev.ExtraSquare, 1));

                            var currentFine =
                                Math.Abs(Math.Round(
                                    resultPackSect.B1 + resultPackSect.B2 + data.AddingB -
                                    (resultPackSect.A1 + resultPackSect.A2 + data.AddingA)
                                    + resultPackSect.ExtraSquare, 1));

                            if (currentFineReverse < currentFine)
                            {
                                currentFine = currentFineReverse;
                                resultPackSect = resultPackSectRev;
                            }

                            if (!(currentFine < fine)) continue;
                            fine = currentFine;
//                            finalPlacementTwoFlat[n] = resultPackSect.B1;
//                            index1 = i;
//                            finalPlacementTwoFlat[n + 1] = resultPackSect.B2;
//                            index2 = j;
//                            finalPlacementOneFlat[n + 1] = resultPackSect.A2;
                        }
                    }
                }



                counter-=2;
            }

            return resultDymMethode.Containers;
        }
    }
}
