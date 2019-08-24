using System;
using FigureAreaBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureAreaBL_UnitTest
{
    [TestClass]
    public class IFigureTest
    {
        [TestMethod]
        public void GetArea_Circle()
        {
            IFigure circle = new Circle(25);
            Assert.AreEqual(Math.PI * 625, circle.GetArea());
        }

        [TestMethod]
        public void GetArea_Triangle()
        {
            IFigure trgl = new Triangle(3, 4, 5);
            Assert.AreEqual(6, trgl.GetArea());
        }

        [TestMethod]
        public void IsCongruent_Circles_True()
        {
            IFigure fig1 = new Circle(13);
            IFigure fig2 = new Circle(13);
            Assert.IsTrue(fig1.IsCongruent(fig2));
        }

        [TestMethod]
        public void IsCongruent_Triangles_True()
        {
            IFigure fig1 = new Triangle(4, 3, 5);
            IFigure fig2 = new Triangle(5, 4, 3);
            Assert.IsTrue(fig1.IsCongruent(fig2));
        }

        [TestMethod]
        public void IsCongruent_Circles_False()
        {
            IFigure fig1 = new Circle(12);
            IFigure fig2 = new Circle(23);
            Assert.IsFalse(fig1.IsCongruent(fig2));
        }

        [TestMethod]
        public void IsCongruent_Triangles_False()
        {
            IFigure fig1 = new Triangle(1, 2, 2);
            IFigure fig2 = new Triangle(2, 2, 2);
            Assert.IsFalse(fig1.IsCongruent(fig2));
        }

        [TestMethod]
        public void IsCongruent_Circle_Triangle()
        {
            IFigure fig1 = new Circle(9);
            IFigure fig2 = new Triangle(2, 3, 4);
            Assert.IsFalse(fig1.IsCongruent(fig2));
        }

        [TestMethod]
        public void IsCongruent_Triangle_Circle()
        {
            IFigure fig1 = new Circle(20);
            IFigure fig2 = new Triangle(6, 4, 5);
            Assert.IsFalse(fig2.IsCongruent(fig1));
        }
    }
}
