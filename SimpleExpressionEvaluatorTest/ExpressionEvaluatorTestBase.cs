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
                VisitsBySubfolder = new System.Collections.Generic.List<KeyValue>()
                {
                    new KeyValue()
                    {
                        key = "pt",
                        value = 34
                    },
                    new KeyValue()
                    {
                        key = "us",
                        value = 2
                    }
                },
                HasPromocodeAvailable = true,
                PageViewsCount = 36,
                PageViewsByDesigner = new System.Collections.Generic.List<KeyValue>()
                {
                    new KeyValue()
                    {
                        key = "gucci",
                        value = 2
                    },
                    new KeyValue()
                    {
                        key = "versace",
                        value = 5
                    }
                },
                PageViewsByType = new System.Collections.Generic.List<KeyValue>()
                {
                    new KeyValue()
                    {
                        key = "shoes",
                        value = 30
                    },
                    new KeyValue()
                    {
                        key = "coats",
                        value = 12
                    }
                },
                Returning = true,
                Channel = new System.Collections.Generic.List<KeyValue>()
                {
                    new KeyValue()
                    {
                        key = "aff",
                        value = 12
                    },
                    new KeyValue()
                    {
                        key = "direct",
                        value = 11
                    }
                },
                LastKnownVisit = new DateTime(2019, 1, 13),
                VisitsByDesigner = new System.Collections.Generic.List<KeyValue>()
                {
                    new KeyValue()
                    {
                        key = "gucci",
                        value = 33
                    },
                    new KeyValue()
                    {
                        key = "versace",
                        value = 40
                    }
                },
                HasWishListProducts = true,
                HasMultipleAddresses = false,
                SpendLevel = "xpto",
                AccessTier = "tier1"
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
