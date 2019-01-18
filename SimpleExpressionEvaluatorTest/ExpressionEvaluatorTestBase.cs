using System;
using SimpleExpressionEvaluator;
using SimpleExpressionEvaluator.Lexer;
using SimpleExpressionEvaluator.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressionEvaluatorTest;
using System.Collections.Generic;

namespace SimpleExpressionEvaluatorTests
{
    [TestClass]
    public class ExpressionEvaluatorTestBase
    {
        public ExpressionEvaluatorTestBase()
        {
            userAggregation = new UserAggregation()
            {
                HasPurchased = true,
                Visits = 20,
                VisitsBySubfolder = new System.Collections.Generic.List<string>()
                {
                    "pt",
                    "us"
                },
                PageViewsByDesigner = new Dictionary<string, int>()
                {
                    { "des1", 2 },
                    { "des2", 4 }
                },
                HasPromocodeAvailable = true,
                PageViewsCount = 36,
                Returning = true,
                LastKnownVisit = new DateTime(2019, 1, 13),
                HasWishListProducts = true,
                HasMultipleAddresses = false,
                SpendLevel = "xpto",
                AccessTier = "tier1",
                NullProp = null
            };
        }

        protected UserAggregation userAggregation { get; set; }

        protected bool Evaluate(string rule)
        {
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(rule, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            return expressionEvaluator.Evaluate<UserAggregation>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, this.userAggregation);
        }
    }
}
