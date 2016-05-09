using System;
using System.Collections.Generic;
using System.Threading;
using ComputationMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Resettlement.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChangeTypeListToArray()
        {
            var list1 = new List<double> {1.02, 2.0, 415.11};
            var resultList = ChangeTypeVariable.ChangeListIntoArray(list1);
            Assert.AreEqual(resultList.Length, 3 , "Не конвертирует в массив");
        }

        [TestMethod]
        public void TestGroupingApartment()
        {
            var list1 = new List<double> { 6.6, 6.6, 7.2, 3.3, 4.8, 3.9, 7.2, 6.6, 6.6, 6.6, 6.3, 6.0 };
            var list2 = new List<double> { 7.8, 7.2, 7.5, 8.1, 7.5, 7.5, 7.5, 7.5, 8.1, 7.8, 8.4, 8.7 };
            var countFloor = 3;
            var resultList = GroupingOnTheFloors.GroupingApartment(list1, list2, countFloor);

            var result0 = new List<double> {4.8, 6.6, 6.6, 7.2};
            var result1 = new List<double> {7.5, 7.5, 8.1, 8.7};
            var result2 = 5.7;

            //Todo писать тест


            Assert.AreEqual((List<double>)resultList[0], result0, "Error in grouping");
            Assert.AreEqual((List<double>)resultList[1], result1, "Error in grouping");
            Assert.AreEqual((double)resultList[2], result2, "Error in grouping");
            Assert.AreEqual((List<double>)resultList[3], new List<double>(), "Error in grouping");
            Assert.AreEqual((List<double>)resultList[4], new List<double>(), "Error in grouping");

            list1.Remove(0);
            list2.Remove(0);
            countFloor = 4;
            resultList = GroupingOnTheFloors.GroupingApartment(list1, list2, countFloor);

            result0 = new List<double> { 4.8, 6.6, 6.6, 7.2 };
            result1 = new List<double> { 7.5, 7.5, 8.1, 8.7 };
            result2 = 5.7;
            var result3 = new List<double> { 4.8, 6.6, 6.6, 7.2 };
            var result4 = new List<double> { 4.8, 6.6, 6.6, 7.2 };

            Assert.AreEqual((List<double>)resultList[0], result0, "Error in grouping");
            Assert.AreEqual((List<double>)resultList[1], result1, "Error in grouping");
            Assert.AreEqual((double)resultList[2], result2, "Error in grouping");
            Assert.AreEqual((List<double>)resultList[3], result3, "Error in grouping");
            Assert.AreEqual((List<double>)resultList[4], result4, "Error in grouping");
        }
    }
}
