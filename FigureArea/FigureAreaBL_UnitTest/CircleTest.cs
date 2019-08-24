using System;
using FigureAreaBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureAreaBL_UnitTest
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void Constructor_NegativeRadius_Exception()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(-5));
        }

        [TestMethod]
        public void Constructor_ZeroRadius_Exception()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(0));
        }

        [TestMethod]
        public void Radius()
        {
            var circle = new Circle(23);
            Assert.AreEqual(23, circle.Radius);
        }

        [TestMethod]
        public void GetArea()
        {
            var circle = new Circle(13);
            Assert.AreEqual(circle.GetArea(), Math.PI * 169);
        }

        [TestMethod]
        public void IsCongruent_AreCongruent()
        {
            var circle = new Circle(12);
            var ncirc = new Circle(circle.Radius);
            Assert.IsTrue(circle.IsCongruent(ncirc));
        }

        [TestMethod]
        public void IsCongruent_AreNotCongruent()
        {
            var circle = new Circle(312);
            var ncirc = new Circle(321);
            Assert.IsFalse(circle.IsCongruent(ncirc));
        }
    }
}
