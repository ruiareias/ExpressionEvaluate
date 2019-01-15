using System;
using SimpleExpressionEvaluator;
using SimpleExpressionEvaluator.Lexer;
using SimpleExpressionEvaluator.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressionEvaluatorTest;

namespace SimpleExpressionEvaluatorTests
{
    [TestClass]
    public class ExpressionEvaluatorTestLists : ExpressionEvaluatorTestBase
    {
        [TestMethod]
        public void SimpleExpressionStringIsNullMethod()
        {           
            Evaluator evaluator = new Evaluator();
            var result1 = evaluator.Evaluate<UserAggregation>(
                " SpendLevel = 'xpto' ", this.userAggregation);
            Assert.AreEqual(result1, true);
            var result2 = evaluator.Evaluate<UserAggregation>(
                " PageViewsCount > (10 * 2) ", this.userAggregation);
            Assert.AreEqual(result2, true);
            Assert.AreEqual(result2, true);
        }
    }
}
