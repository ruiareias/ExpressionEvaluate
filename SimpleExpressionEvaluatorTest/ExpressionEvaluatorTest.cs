using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine;
using SimpleExpressionEvaluator;
using SimpleExpressionEvaluatorTest;
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
            string text = "(HasPurchased = true && PageViewsCount > (10 * 2) && LastKnownVisit <= '2019-01-20') && SpendLevel like '?pt?'";
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
        public void TestThenElse1()
        {
            string text = "(GetPageViewsCount() < 10)";
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

        [TestMethod]
        public void TestFilterBySubFolder()
        {
            string text = "FilterBySubFolder('pt2')";
            bool result = this.Evaluate(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void xpto()
        {
            string text = "IntAn1y'(this, 'pt')";
            bool result = this.Evaluate(text);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void TestFilterPageViewsByDesigner()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int c = 0; c < 1000000; c++)
            {
                string text = "FilterPageViewsByDesigner('des13', 2) &&(5 * 6 + 7.5 - 0.5) + Visits = 57 && SpendLevel = 'xpto' && PageViewsCount = Visits + 16";
                bool result = this.Evaluate(text);
            }
            stopwatch.Stop();
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 4000);
        }

        //rules engine

        [TestMethod]
        public void DynamicBaseClassCollectionNotInTest()
        {
            DynamicBaseClass person = new DynamicBaseClass()
            { Name = "Person", ReferenceName = "person", Type = ObjectType.Object };
            person.Fields.Add(new { Name = "Joe", Country = "Ireland", Age = 60 });

            DynamicBaseClass collection = new DynamicBaseClass()
            { Name = "CollectionPerson", ReferenceName = "collectionperson", Type = ObjectType.Collection };
            collection.Fields.Add(new { Name = "Joe", Country = "Ireland", Age = 20 });
            collection.Fields.Add(new { Name = "Bert", Country = "USA", Age = 40 });
            collection.Fields.Add(new { Name = "Carl", Country = "USA", Age = 50 });
            collection.Fields.Add(new { Name = "Carol", Country = "Germany", Age = 60 });

            //ExpressionRuleLoader expressionRuleLoader = new ExpressionRuleLoader();
            Rule rule1 = new Rule(" person[Age] notin collectionperson[Age] ");
            RuleValidator ruleValidator = new RuleValidator();
            var result = ruleValidator.ValidateExpressionRulesAll(
                new DynamicBaseClass[] { person, collection },
                new Rule[] { rule1 });
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void SimpleExpressionStringIsNullMethod()
        {
            Evaluator evaluator = new Evaluator();
            var result1 = evaluator.Evaluate<UserAggregation>(
                " SpendLevel = 'xpto' ", this.userAggregation);
            Assert.AreEqual(result1, true);
            var result2 = evaluator.Evaluate<UserAggregation>(
                " PageViewsCount > (10 * 2) ", this.userAggregation);
            Assert.AreEqual(result1, true);
            Assert.AreEqual(result2, true);
        }

        //[TestMethod]
        //public void TestIs()
        //{
        //    Evaluator evaluator = new Evaluator();
        //    var result = evaluator.Evaluate(
        //        "NullProp is null", this.userAggregation);
        //    Assert.AreEqual(result, true);
        //}


        //[TestMethod]
        //public void TestIs1()
        //{
        //    Evaluator evaluator = new Evaluator();
        //    var result1 = evaluator.Evaluate<UserAggregation>(
        //        " SpendLevel = 'xpto' ", this.userAggregation);
        //    Assert.AreEqual(result1, true);
        //    var result2 = evaluator.Evaluate<UserAggregation>(
        //        " PageViewsCount > 34 ", this.userAggregation);
        //    Assert.AreEqual(result2, true);
        //    var result3 = evaluator.Evaluate<UserAggregation>(
        //       " SpendLevel notin 'xpto1'", this.userAggregation);
        //    Assert.AreEqual(result3, false);
        //}
    }
}
