using System;
using SimpleExpressionEvaluator;
using SimpleExpressionEvaluator.Lexer;
using SimpleExpressionEvaluator.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressionEvaluatorTest;

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
                VisitsBySubfolder = new System.Collections.Generic.Dictionary<string, int>()
                {
                    { "pt", 34},
                    { "us", 2},
                },
                HasPromocodeAvailable = true,
                PageViewsCount = 36,
                PageViewsByDesigner = new System.Collections.Generic.Dictionary<string, int>()
                {
                    { "gucci", 3},
                    { "versace", 5},
                },
                PageViewsByType = new System.Collections.Generic.Dictionary<string, int>()
                {
                    { "shoes", 30},
                    { "coats", 12},
                },
                Returning = true,
                Channel = new System.Collections.Generic.Dictionary<string, int>()
                {
                    { "aff", 12},
                    { "direct", 11},
                },
                LastKnownVisit = new DateTime(2019, 1, 13),
                VisitsByDesigner = new System.Collections.Generic.Dictionary<string, int>()
                {
                    { "gucci", 33},
                    { "versace", 40},
                },
                HasWishListProducts = true,
                HasMultipleAddresses = false,
                SpendLevel = "xpto",
                AccessTier = "tier1"
            };
        }

        protected UserAggregation userAggregation { get; set; }

        protected bool Setup(string rule)
        {
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(rule, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            return expressionEvaluator.Evaluate<UserAggregation>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, this.userAggregation);
        }
    }
}
