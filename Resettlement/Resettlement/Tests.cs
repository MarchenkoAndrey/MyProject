using System.Collections.Generic;
using System.Linq;
using ComputationMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Resettlement
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestChangeTypeListToArray()
        {
            var list1 = new List<double> {1.02, 2.0, 415.11};
            var resultList = ChangeTypeVariable.ChangeListIntoArray(list1);
            Assert.AreEqual(resultList.Length, 3, "Not converted in array");
        }

        [TestMethod]
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

    }
}

