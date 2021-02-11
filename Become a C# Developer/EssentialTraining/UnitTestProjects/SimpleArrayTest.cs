using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTraining;

namespace UnitTestProjects
{
    [TestClass]
    public class SimpleArrayTest
    {
        [TestMethod]
        public void TestInstantiation()
        {
            var testInstance = new SimpleArray();
            Assert.AreEqual(testInstance.GroceryList.Length, 4);
            Assert.AreEqual(testInstance.GroceryList[1], "milk");
            
        }

        [TestMethod]
        public void TestToString()
        {
            var testInstance = new SimpleArray();
            Assert.IsTrue(testInstance.makeString().StartsWith("There are"));
        }

        [TestMethod]
        public void TestisSauceAwesome()
        {
            var testInstance = new SimpleArray();
            Assert.IsTrue(testInstance.isSauceAwesome("Red Sauce"));
            Assert.IsFalse(testInstance.isSauceAwesome("Sauce"));
        }
    }

    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void TestInstantiation()
        {
            var testInstance = new Dictionary();
            testInstance.Contacts.Add("Autumn", "3423452345");
            Assert.AreEqual(testInstance.getNumber("Autumn"), "3423452345");

        }
    }

}
