using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VendingMachine;

namespace VendingMachine.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CostOfSodaTest()
        {
            var pp = new VendingMachine(55);

            Assert.AreEqual(pp.CostOfSoda, 55);
        }

        [TestMethod]
        public void AmountSpentTest()
        {
            var pp = new VendingMachine(5);
            int spent = 0;
            for (int i = 1; i <= 5; i++)
            {
                pp.GetEnteredAmount(i.ToString());
                spent += i;
                Assert.AreEqual(spent, pp.AmountSpent);
            }
        }

        [TestMethod]
        public void GetEnteredAmountNullTest()
        {
            var pp = new VendingMachine(44);
            Assert.ThrowsException<ArgumentNullException>(() => pp.GetEnteredAmount(null));
        }

        [TestMethod]
        public void GetEnteredAmountInvalidTest()
        {
            var pp = new VendingMachine(44);
            Assert.ThrowsException<ArgumentException>(() => pp.GetEnteredAmount("four"));
        }

        [TestMethod]
        public void GetEnteredAmountTest()
        {
            var pp = new VendingMachine(44);
            pp.GetEnteredAmount("10");
            Assert.AreEqual(pp.AmountSpent, 10);
            pp.GetEnteredAmount("10");
            Assert.AreEqual(pp.AmountSpent, 20);
        }

        [TestMethod]
        public void IsAmountSufficientTest()
        {
            var pp = new VendingMachine(50);
            pp.GetEnteredAmount("30");

            Assert.IsFalse(pp.IsAmountSufficient());

            pp.GetEnteredAmount("20");
            Assert.IsTrue(pp.IsAmountSufficient());
        }
    }
}
