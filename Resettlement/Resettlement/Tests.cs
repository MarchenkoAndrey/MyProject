using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Resettlement
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [Category("Grouping")]
        public void TestGroupingNotExceed()
        {
            const int countFloor = 3;
            const double optFine = 5.7;
            var list1 = new List<double> {6.6, 6.6, 7.2, 3.3, 4.8, 3.9, 7.2, 6.6, 6.6, 6.6, 6.3, 6.0};
            var list2 = new List<double> {7.8, 7.2, 7.5, 8.1, 7.5, 7.5, 7.5, 7.5, 8.1, 7.8, 8.4, 8.7};
            var optItem1 = new List<double> { 4.8, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 7.5, 7.5, 8.1, 8.7 };

            var result = GroupingOnTheFloors.GroupingFlat(new InputDataAlg(list1, list2, countFloor));

            Assert.AreEqual(result.ListResultOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.ListResultTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
        }

        [TestMethod]
        [Category("Grouping")]
        public void TestGroupingOneExceed()
        {
            const int countFloor = 2;
            const double optFine = 1.2;
            var list1 = new List<double> { 6.6, 7.2, 3.3, 4.8, 3.9, 7.2, 6.6, 6.6, 6.6 };
            var list2 = new List<double> { 7.2, 7.5, 8.1, 7.5, 7.5, 7.5, 8.1, 7.8, 8.4 };
            var optItem1 = new List<double> { 3.9, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 7.5, 7.5, 8.1, 8.4 };
            var optItem3 = new List<double> { 4.8 };
            var optItem4 = new List<double> { 7.2 };

            var result = GroupingOnTheFloors.GroupingFlat(new InputDataAlg(list1, list2, countFloor));

            Assert.AreEqual(result.ListResultOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.ListResultTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
            Assert.AreEqual(result.ListExcessOneFlat.Except(optItem3).ToList().Count, 0);
            Assert.AreEqual(result.ListExcessTwoFlat.Except(optItem4).ToList().Count, 0);
        }

        [TestMethod]
        [Category("Grouping")]
        public void TestGroupingThreeExceed()
        {
            const int countFloor = 4;
            const double optFine = 3.0;
            var list1 = new List<double> {6.6, 7.2, 3.3, 4.8, 3.9, 7.2, 6.6, 6.6, 6.6, 6.3, 6.0};
            var list2 = new List<double> {7.2, 7.5, 8.1, 7.5, 7.5, 7.5, 7.5, 8.1, 7.8, 8.4, 8.7};
            var optItem1 = new List<double> { 6.6, 7.2 };
            var optItem2 = new List<double> { 7.5, 8.1 };
            var optItem3 = new List<double> { 3.3, 3.9, 4.8 };
            var optItem4 = new List<double> { 7.2, 8.4, 8.7 };

            var result = GroupingOnTheFloors.GroupingFlat(new InputDataAlg(list1, list2, countFloor));

            Assert.AreEqual(result.ListResultOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.ListResultTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
            Assert.AreEqual(result.ListExcessOneFlat.Except(optItem3).ToList().Count, 0);
            Assert.AreEqual(result.ListExcessTwoFlat.Except(optItem4).ToList().Count, 0);
        }
        
        [TestMethod]
        [Category("GreedyMethode")]
        public void TestGreedyMethode()
        {
            //Tests 10flat
            const int optCountFlat = 4;
            const double optFine = 3.6;
            const double oneFirstFlat = 7.2;
            const double startFlat = 0.0;
            var list1 = new List<double> { 3.9, 6.6, 6.6, 7.2 };
            var list2 = new List<double> { 7.5, 7.5, 7.8, 8.1 };
            var optItem1 = new List<double> { 3.9, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 8.1, 8.1, 8.7, 7.5 };
            
            var result = GreedyMethodeSect.GreedyMethode(new DataGreedyMethode(list1, list2, optCountFlat), startFlat);
            Assert.AreEqual(result.FinalPlaceOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.FinalPlaceTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
            Assert.AreEqual(result.NewFirstOneFlat,oneFirstFlat);
        }

        //TODO Добавить тест на проверку конкретных итераций

        [TestMethod]
        [Category("GreedyMethode")]
        public void TestGreedyMethodeI()
        {
            //Tests 12flat
            const int optCountFlat = 6;
            const double optFine = 3.0;
            const double oneFirstFlat = 6.6;
            const double startFlat = 0.0;
            var list1 = new List<double> { 3.9, 6.0, 6.6, 6.6, 6.6, 7.2 };
            var list2 = new List<double> { 7.5, 7.5, 7.5, 7.8, 8.1, 8.7 };
            var optItem1 = new List<double> { 3.9, 6.0, 6.6, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 8.1, 8.7, 8.1, 7.5, 8.1, 7.5 };

            var result = GreedyMethodeSect.GreedyMethode(new DataGreedyMethode(list1, list2, optCountFlat), startFlat);
            Assert.AreEqual(result.FinalPlaceOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.FinalPlaceTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
            Assert.AreEqual(result.NewFirstOneFlat, oneFirstFlat);
        }

        [TestMethod]
        [Category("GreedyMethode")]
        public void TestGreedyMethodeI2()
        {
            //tests 12flat 2Iter
            const int optCountFlat = 6;
            const double optFine = 3.0;
            const double oneFirstFlat = 6.6;
            const double startFlat = 6.6;
            var list1 = new List<double> { 3.9, 6.0, 6.6, 6.6, 6.6, 7.2 };
            var list2 = new List<double> { 7.5, 7.5, 7.5, 7.8, 8.1, 8.7 };
            var optItem1 = new List<double> { 3.9, 6.0, 6.6, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 8.1, 8.7, 8.1, 7.5, 8.1, 7.5 };

            var result = GreedyMethodeSect.GreedyMethode(new DataGreedyMethode(list1, list2, optCountFlat), startFlat);
            Assert.AreEqual(result.FinalPlaceOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.FinalPlaceTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
            Assert.AreEqual(result.NewFirstOneFlat, oneFirstFlat);
        }

        [TestMethod]
        [Category("FullSearch")]
        public void TestFullSearch12()
        {
            //tests 12flat
            const int optCountFlat = 6;
            const double optFine = 3.0;
            var list1 = new List<double> { 3.9, 6.0, 6.6, 6.6, 6.6, 7.2 };
            var list2 = new List<double> { 7.5, 7.5, 7.5, 7.8, 8.1, 8.7 };
            var optItem1 = new List<double> { 3.9, 6.0, 6.6, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 8.1, 8.7, 8.1, 7.5, 8.1, 7.5 };

            var result = MethodeFullSearch.FullSearch(new DataPerformAlgorithm(list1, list2), optCountFlat);
            Assert.AreEqual(result.ListResultOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.ListResultTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
        }

        [TestMethod]
        [Category("FullSearch")]
        public void TestFullSearch8()
        {
            //tests 10flat
            const int optCountFlat = 6;
            const double optFine = 3.6;
            var list1 = new List<double> { 3.9, 6.6, 6.6, 7.2 };
            var list2 = new List<double> { 7.5, 7.5, 7.8, 8.1 };
            var optItem1 = new List<double> { 3.9, 6.6, 6.6, 7.2 };
            var optItem2 = new List<double> { 8.1, 8.1, 8.7, 7.5 };

            var result = MethodeFullSearch.FullSearch(new DataPerformAlgorithm(list1, list2), optCountFlat);
            Assert.AreEqual(result.ListResultOneFlat.Except(optItem1).ToList().Count, 0);
            Assert.AreEqual(result.ListResultTwoFlat.Except(optItem2).ToList().Count, 0);
            Assert.AreEqual(result.Fine, optFine);
        }
    }
}

