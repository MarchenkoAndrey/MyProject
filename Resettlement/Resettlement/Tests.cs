using System.Collections.Generic;
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
        public static void TestGroupingApartment1()
        {
            var list1 = new List<double> {6.6, 6.6, 7.2, 3.3, 4.8, 3.9, 7.2, 6.6, 6.6, 6.6, 6.3, 6.0};
            var list2 = new List<double> {7.8, 7.2, 7.5, 8.1, 7.5, 7.5, 7.5, 7.5, 8.1, 7.8, 8.4, 8.7};
            const int countFloor = 3;

            var resultList = GroupingOnTheFloors.GroupingFlat(new InputDataAlg(list1, list2, countFloor));

            var result0 = new List<double> {4.8, 6.6, 6.6, 7.2};
            var result1 = new List<double> {7.5, 7.5, 8.1, 8.7};
            const double result2 = 5.7;

            Assert.AreEqual(resultList.ListResultOneFlat, result0);
            Assert.AreEqual(resultList.ListResultTwoFlat, result1);
            Assert.AreEqual(resultList.Fine, result2);
        }

        [TestMethod]
        public static void TestGroupingApartment2()
        {
            var list1 = new List<double> {6.6, 7.2, 3.3, 4.8, 3.9, 7.2, 6.6, 6.6, 6.6, 6.3, 6.0};
            var list2 = new List<double> {7.2, 7.5, 8.1, 7.5, 7.5, 7.5, 7.5, 8.1, 7.8, 8.4, 8.7};
            const int countFloor = 4;
            var resultList = GroupingOnTheFloors.GroupingFlat(new InputDataAlg(list1, list2, countFloor));

            var result0 = new List<double> {4.8, 6.6, 6.6, 7.2};
            var result1 = new List<double> {7.5, 7.5, 8.1, 8.7};
            const double result2 = 5.7;
            var result3 = new List<double> {4.8, 6.6, 6.6, 7.2};
            var result4 = new List<double> {4.8, 6.6, 6.6, 7.2};

            Assert.AreEqual(resultList.ListResultOneFlat, result0);
            Assert.AreEqual(resultList.ListResultTwoFlat, result1);
            Assert.AreEqual(resultList.Fine, result2);
            Assert.AreEqual(resultList.ListExcessOneFlat, result3);
            Assert.AreEqual(resultList.ListExcessTwoFlat, result4);
        }
    }
}

