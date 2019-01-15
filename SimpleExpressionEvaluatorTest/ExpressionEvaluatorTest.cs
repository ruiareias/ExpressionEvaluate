using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SimpleExpressionEvaluatorTests
{
    [TestClass]
    public class TestMethod : ExpressionEvaluatorTestBase
    {
        [TestMethod]
        public void BasicTest()
        {
            string text = "(HasPurchased = true && PageViewsCount > (10 * 2) && LastKnownVisit <= '2019-01-20') || SpendLevel = 'xpto1'";
            bool result = this.Evaluate(text);            
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void BasicTestWithMathOperations()
        {
            string text = "(5 * 6 + 7.5 - 0.5) + Visits = 57 && SpendLevel = 'xpto' && PageViewsCount = Visits + 16 && PageViewsCount >= Visits / 20 && (5 + 3 > 2 * 1)";
            bool result = this.Evaluate(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void TestLike()
        {
            string text = "(HasPurchased = true && PageViewsCount > (10 * 2) && LastKnownVisit <= '2019-01-20') && SpendLevel like 'xpt?'";
            bool result = this.Evaluate(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void TestThenElse()
        {
            string text = "(PageViewsCount > 10) then SetCanReceiveBenefits(true) else SetCancelBenefits(true)";
            bool result = this.Evaluate(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void TestNot()
        {
            string text = "SpendLevel ! 'xpto1'";
            bool result = this.Evaluate(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void TestPerformance()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int c = 0; c <100000; c++)
            {
                string text = "(5 * 6 + 7.5 - 0.5) + Visits = 57 && SpendLevel = 'xpto' && PageViewsCount = Visits + 16";
                this.Evaluate(text);
            }
            stopwatch.Stop();
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 4000);
        }
    }
}
