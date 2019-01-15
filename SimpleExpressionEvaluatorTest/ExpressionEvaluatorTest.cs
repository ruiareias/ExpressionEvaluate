using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleExpressionEvaluatorTests
{
    [TestClass]
    public class ExpressionEvaluatorTest : ExpressionEvaluatorTestBase
    {
        [TestMethod]
        public void BasicTest()
        {
            string text = "(HasPurchased = true && PageViewsCount > (10 * 2) && LastKnownVisit <= '2019-01-20') || SpendLevel = 'xpto1'";
            bool result = this.Setup(text);            
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void BasicTestWithMathOperations()
        {
            string text = "(5 * 6 + 7.5 - 0.5) + Visits = 57 && SpendLevel = 'xpto' && PageViewsCount = Visits + 16 && PageViewsCount >= Visits / 20 && (5 + 3 > 2 * 1)";
            bool result = this.Setup(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void TestSet()
        {
            string text = "(HasPurchased = true && PageViewsCount > (10 * 2) && LastKnownVisit <= '2019-01-20') || SpendLevel = 'xpto1' set SetCanReceiveBenefits(true)";
            bool result = this.Setup(text);
            Assert.AreEqual<bool>(result, true);
        }
    }
}
