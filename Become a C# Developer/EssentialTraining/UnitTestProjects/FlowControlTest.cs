using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTraining;

namespace UnitTestProjects
{
    [TestClass]
    public class FlowControlTest
    {
        [TestMethod]
        public void IsFavColorBlueTest()
        {
            var testInstance = new FlowControl();
            Assert.IsTrue(testInstance.IsFavColorBlue("blue"));
            Assert.IsFalse(testInstance.IsFavColorBlue("red"));
        }

        [TestMethod]
        public void IsFavColorRedTest()
        {
            var testInstance = new FlowControl();
            Assert.IsTrue(testInstance.IsFavColorRed("red"));
            Assert.IsFalse(testInstance.IsFavColorRed("blue"));
        }

        [TestMethod]
        public void IsFavColorGreenTest()
        {
            var testInstance = new FlowControl();
            Assert.IsTrue(testInstance.IsFavColorGreen("green"));
            Assert.IsFalse(testInstance.IsFavColorGreen("blue"));
        }

        [TestMethod]
        public void PrimaryOrSecondaryTest()
        {
            var testInstance = new FlowControl();
            Assert.AreEqual(testInstance.PrimaryOrSecondary("red"),"Is Primary");
            Assert.AreEqual(testInstance.PrimaryOrSecondary("blue"), "Is Primary");
            Assert.AreEqual(testInstance.PrimaryOrSecondary("yellow"), "Is Primary");
            Assert.AreEqual(testInstance.PrimaryOrSecondary("green"), "Is Secondary");
        }
    }
}
