using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleExpressionEvaluatorTests
{
    [TestClass]
    public class ExpressionEvaluatorTest : ExpressionEvaluatorTestBase
    {
        [TestMethod]
        public void ExpressionStringTest()
        {
            string text = "(HasPurchased = true && PageViewsCount > (10 * 2) && LastKnownVisit <= '2019-01-20') || SpendLevel = 'xpto1'";
            bool result = this.Setup(text);            
            Assert.AreEqual<bool>(result, true);
        }

        //[TestMethod]
        //public void ExpressionBoolTest()
        //{
        //    string text = " Married = true ";
        //    Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
        //    ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
        //    ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
        //    var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
        //    ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
        //    var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
        //    Assert.AreEqual<bool>(result, true);
        //}

        //[TestMethod]
        //public void ExpressionIntegerTest()
        //{
        //    string text = " Age = 5 * 6 + 7 - 1 ";
        //    Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
        //    ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
        //    ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
        //    var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
        //    ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
        //    var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
        //    Assert.AreEqual<bool>(result, true);
        //}

        //[TestMethod]
        //public void ExpressionModuloTest()
        //{
        //    string text = " Age = 100 % 64 ";
        //    Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
        //    ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
        //    ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
        //    var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
        //    ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
        //    var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
        //    Assert.AreEqual<bool>(result, true);
        //}

        //[TestMethod]
        //public void ExpressionTest()
        //{
        //    Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };

        //    //string text = " test > 10 ";
        //    //string text = " 5 + 3 > 2 * 1 ";
        //    //string text = " 5 * 3 + 2 * 1 ";    
        //    string text = " Children * 2 + 5 = 9 && Married = true && Age > 36 && Age = (5 * 6 + 8 - 1) && Name = 'mathias'";
        //    //string text = " Children * 2.0 + 5.0 = 9.0 ";
        //    //string text = " Children * 2.0 + 5.0 = 9.0 && Married = true && Age = Children * 18 ";
        //    //var text = " Children >= Age / 20 && Name != 'test' ";

        //    ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
        //    ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
        //    var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
        //    ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();

        //    for (int c = 0; c <= 100000; c++)
        //    {

        //        var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);

        //    }
        //    Assert.AreEqual<bool>(true, true);
        //}

        //[TestMethod]
        //public void SimpleExpressionEvaluatorWithSetMethod()
        //{
        //    Person person1 = new Person()
        //    {
        //        Name = "Mathias",
        //        Age = 36,
        //        Children = 2,
        //        Married = true,
        //        Birthdate = new DateTime(1976, 5, 9)
        //    };
        //    Person person2 = new Person()
        //    {
        //        Name = "Anna",
        //        Age = 32,
        //        Children = 2,
        //        Married = false,
        //        Birthdate = new DateTime(2002, 2, 2)
        //    };
        //    Evaluator evaluator = new Evaluator();
        //    var result = evaluator.Evaluate("(Age > 10 && Birthdate > '1976-03-05') set SetCanReceiveBenefits(true)", person1);
        //    Assert.AreEqual(result, true);
        //    Assert.AreEqual(person1.ReceiveBenefits, true);
        //}

//        [TestMethod]
//        public void SimpleRuleLoaderPersonEvaluateExpressionAny()
//        {
//            Person person1 = new Person() { Name = “Mathias”, Age = 36, Children = 2 };
//            Person person2 = new Person() { Name = “Anna”, Age = 35, Children = 2 };

//            List rules = new List();
//            Rule(” Name = ‘Mathias’ “));
//            Rule(” Age = 35 “));

//            RuleValidator ruleValidator = new RuleValidator();
//            var result = ruleValidator.ValidateExpressionRulesAny(new Person[] { person1, person2 },
//            rules);
//            Assert.AreEqual(result, true);
//        }

//        [TestMethod]
//        public void SimpleRuleLoaderPersonEvaluateFoundInExpression()
//        {
//            Person person1 = new Person() { Name = “Mathias”, Age = 36, Children = 2 };
//            Person person2 = new Person() { Name = “Anna”, Age = 35, Children = 2 };
//            Person person3 = new Person() { Name = “Emil”, Age = 4, Children = 0 };

//            List persons = new List();
//);
//);

//            RuleEngine.RuleEngine ruleEngine = new RuleEngine.RuleEngine();
//            var ruleFunc =
//            ruleEngine.CompileRule(“Name”, Operator.FoundIn, persons);
//            var result = ruleFunc(person1);

//            Rule rule = new Rule(“Name”, Operator.FoundIn, persons);
//            var ruleFuncRule =
//            ruleEngine.CompileRule(rule);

//            var ruleFuncRuleResult = ruleFuncRule(person3);
//            Assert.AreEqual(result, true);
//            Assert.AreEqual(ruleFuncRuleResult, false);
//        }
    }
}
