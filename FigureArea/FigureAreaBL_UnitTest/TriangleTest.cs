using System;
using FigureAreaBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureAreaBL_UnitTest
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void Constructor_NegativeArgument()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, 7, -1));
        }

        [TestMethod]
        public void Constructor_ZeroArgument()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(0, 5, 5));
        }

        [TestMethod]
        public void Constructor_Inequaty_Eq()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 2, 3));
        }

        [TestMethod]
        public void Constructor_Inequaty_Gt()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(2, 3, 7));
        }

        [TestMethod]
        public void MinSide()
        {
            var trg = new Triangle(8, 5, 6);
            Assert.AreEqual(5, trg.MinSide);
        }

        [TestMethod]
        public void MidSide()
        {
            var trg = new Triangle(7, 3, 9);
            Assert.AreEqual(7, trg.MidSide);
        }

        [TestMethod]
        public void MaxSide()
        {
            var trg = new Triangle(2, 3, 4);
            Assert.AreEqual(4, trg.MaxSide);
        }

        [TestMethod]
        public void IsRight_True()
        {
            var trg = new Triangle(24, 7, 25);
            Assert.IsTrue(trg.IsRight());
        }

        [TestMethod]
        public void IsRight_False()
        {
            var trg = new Triangle(5, 7, 11);
            Assert.IsFalse(trg.IsRight());
        }

        [TestMethod]
        public void GetArea_IsRight()
        {
            var trg = new Triangle(25, 24, 7);
            Assert.AreEqual(84, trg.GetArea());
        }

        [TestMethod]
        public void GetArea_NotRight()
        {
            var trg = new Triangle(25, 40, 39);
            Assert.AreEqual(468, trg.GetArea());
        }

        [TestMethod]
        public void IsCongruent_True()
        {
            var trg1 = new Triangle(2, 7, 8);
            var trg2 = new Triangle(7, 2, 8);
            Assert.IsTrue(trg1.IsCongruent(trg2));
        }

        public void IsCongruent_False()
        {
            var trg1 = new Triangle(36, 90, 120);
            var trg2 = new Triangle(80, 82, 84);
            Assert.IsFalse(trg1.IsCongruent(trg2));
        }
    }
}
