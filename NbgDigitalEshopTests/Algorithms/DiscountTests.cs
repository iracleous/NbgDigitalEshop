using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbgDigitalEshop.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Algorithms.Tests
{
    [TestClass()]
    public class DiscountTests
    {
        [TestMethod()]
        public void CalculateDiscountTest()
        {
            var discount = new Discount() { InitialValue = 1.50m};
            var discountValue = discount.CalculateDiscount(22);
            Assert.AreEqual(0.15m, discountValue );

            var number1 = 0.1m;
            var number2 = 0.2m;
            Assert.AreEqual(0.3m, number1 + number2);
        }
    }
}