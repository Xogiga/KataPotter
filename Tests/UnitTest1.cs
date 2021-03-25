using CodePotter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestPotter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBasics()
        {
            Assert.AreEqual(0, PotterBooks.PriceAllBooks(new List<int>()));
            Assert.AreEqual(8, PotterBooks.PriceAllBooks(new List<int> { 1 }));
            Assert.AreEqual(8, PotterBooks.PriceAllBooks(new List<int> { 2 }));
            Assert.AreEqual(8, PotterBooks.PriceAllBooks(new List<int> { 3 }));
            Assert.AreEqual(8, PotterBooks.PriceAllBooks(new List<int> { 4 }));
            Assert.AreEqual(8, PotterBooks.PriceAllBooks(new List<int> { 5 }));
            Assert.AreEqual(24, PotterBooks.PriceAllBooks(new List<int> { 1, 1, 1 }));

        }

        [TestMethod]
        public void TestSimpleDiscounts()
        {
            Assert.AreEqual(8 * 2 * 0.95, PotterBooks.PriceAllBooks(new List<int> { 1, 2 }));
            Assert.AreEqual(8 * 3 * 0.9, PotterBooks.PriceAllBooks(new List<int> { 1, 3, 5 }));
            Assert.AreEqual(8 * 4 * 0.8, PotterBooks.PriceAllBooks(new List<int> { 1, 2, 3, 5 }));
            Assert.AreEqual(8 * 5 * 0.75, PotterBooks.PriceAllBooks(new List<int> { 1, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void TestSeveralDiscounts()
        {
            Assert.AreEqual(8 + (8 * 2 * 0.95), PotterBooks.PriceAllBooks(new List<int> { 1, 1, 2 }));
            Assert.AreEqual(2 * (8 * 2 * 0.95), PotterBooks.PriceAllBooks(new List<int> { 1, 1, 2, 2 }));
            Assert.AreEqual((8 * 4 * 0.8) + (8 * 2 * 0.95), PotterBooks.PriceAllBooks(new List<int> { 1, 1, 2, 3, 3, 4 }));
            Assert.AreEqual(8 + (8 * 5 * 0.75), PotterBooks.PriceAllBooks(new List<int> { 1, 2, 2, 3, 4, 5 }));
        }

        public void TestEdgeCases()
        {
            Assert.AreEqual(2 * (8 * 4 * 0.8), PotterBooks.PriceAllBooks(new List<int> { 1, 1, 2, 2, 3, 3, 4, 5 }));
            Assert.AreEqual(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8), 
                PotterBooks.PriceAllBooks(new List<int> {
                    1, 1, 1, 1, 1,
                    2, 2, 2, 2, 2,
                    3, 3, 3, 3,
                    4, 4, 4, 4, 4,
                    5, 5, 5, 5}));
        }
    }
}
