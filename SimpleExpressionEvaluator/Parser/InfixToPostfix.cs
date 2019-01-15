using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressionEvaluator.AbstractSyntaxTree;

namespace SimpleExpressionEvaluator.Parser
{
    public class InfixToPostfix
    {
        //implementation with List and Operator Stack convert infix espression (5 + 3 * 2 - 1) to postfix expression and then calculate value ( 10 )
        //first convert infix to postfix expression and save in list (5 + 3 * 2 - 1 => 5 3 2 * 1 - +)
        //5 => to List ( 5 )
        //+ => to Operator Stack ( + )
        //3 => to List ( 5, 3 )
        //* => to Operator Stack ( +, * )
        //2 => to List ( 5, 3, 2 )
        //- => lower precedence than * on Stack => to List ( 5, 3, 2, * ) => Operator Stack ( +, - )
        //1 => to List ( 5, 3, 2, *, 1 )
        //pop Operator Stack ( +, - ) => to List ( 5, 3, 2, *, 1, -, + )
        //second calculate the result out of the genenerated list with the postfix expression with a Stack
        //5 => Stack ( 5 )
        //3 => Stack ( 5, 3 )
        //2 => Stack ( 5, 3, 2 )
        //* => 2 from Stack 3 from Stack change operators ( 5 ) => calculate 3 * 2 = 6 => Stack ( 5, 6 )
        //1 => Stack ( 5, 6, 1 )
        //- => 1 from Stack 6 from Stack change operators ( 5 ) => calculate 6 - 1 = 5 => Stack ( 5, 5 )
        //+ => 5 from Stack 5 from Stack change operators ( ) => calculate 5 + 5 => Stack ( 10 )
        public List<AbstractSyntaxTreeNode> ConvertInfixToPostfix(List<AbstractSyntaxTreeNode> postfixList)
        {
            List<AbstractSyntaxTreeNode> returnList = new List<AbstractSyntaxTreeNode>();
            Stack<AbstractSyntaxTreeNode> operatorStack = new Stack<AbstractSyntaxTreeNode>();
            var position = 0;
            for (int i = position; i < postfixList.Count; i++)            
            {
                var item = postfixList[i];
                if (item is IntegerNode || item is DoubleNode || item is VariableNode ||
                    item is BooleanNode || item is StringNode || item is NullNode)
                {
                    returnList.Add(item);
                }
                else if (item is OpenBracketNode)
                {
                    i = ConvertInfixToPostfixBracket(i, postfixList, returnList);
                }
                else if (item is OrNode || item is AndNode)
                {
                    while (operatorStack.Count > 0)
                    {
                        var abstractSyntaxTreeNode = operatorStack.Pop();
                        returnList.Add(abstractSyntaxTreeNode);
                    }
                    operatorStack.Push(item);
                }
                else if (item is GreaterThenNode || item is GreaterThenOrEqualNode ||
                    item is SmallerThenNode || item is SmallerThenOrEqualNode ||
                    item is EqualNode || item is UnEqualNode || item is IsNode || item is LikeNode)
                {
                    if (operatorStack.Count() > 0 && (operatorStack.Peek() is MulNode || 
                        operatorStack.Peek() is DivNode ||
                        operatorStack.Peek() is ModuloNode))
                    {
                        AbstractSyntaxTreeNode node = operatorStack.Pop();
                        returnList.Add(node);
                    }
                    else if (operatorStack.Count() > 0 && (operatorStack.Peek() is AddNode || 
                        operatorStack.Peek() is SubNode))
                    {
                        AbstractSyntaxTreeNode node = operatorStack.Pop();
                        returnList.Add(node);
                    }
                    operatorStack.Push(item);
                }
                else if (item is AddNode || item is SubNode)
                {
                    if (operatorStack.Count() > 0 && (operatorStack.Peek() is MulNode || 
                        operatorStack.Peek() is DivNode ||
                        operatorStack.Peek() is ModuloNode))
                    {
                        AbstractSyntaxTreeNode node = operatorStack.Pop();
                        returnList.Add(node);
                    }
                    operatorStack.Push(item);
                }
                else if (item is MulNode || item is DivNode || item is ModuloNode)
                {
                    operatorStack.Push(item);
                }
                else if (item is SetNode || item is ThenNode || item is ElseNode)
                {
                    operatorStack.Push(item);
                }
                position++;
            }
            while (operatorStack.Count > 0)
            {
                var abstractSyntaxTreeNode = operatorStack.Pop();
                returnList.Add(abstractSyntaxTreeNode);
            }
            return returnList;
        }

        public int ConvertInfixToPostfixBracket(int position, 
            List<AbstractSyntaxTreeNode> postfixList, List<AbstractSyntaxTreeNode> returnList)
        {
            Stack<AbstractSyntaxTreeNode> operatorStack = new Stack<AbstractSyntaxTreeNode>();
            int i = 0;
            for (i = position + 1; i < postfixList.Count; i++)
            {
                var item = postfixList[i];
                if (item is CloseBracketNode)
                {
                    break;
                }
                if (item is IntegerNode || item is DoubleNode || item is VariableNode || item is BooleanNode || item is StringNode)
                {
                    returnList.Add(item);
                }
                else if (item is OpenBracketNode)
                {
                    i = ConvertInfixToPostfixBracket(i, postfixList, returnList);
                }
                else if (item is OrNode || item is AndNode)
                {
                    while (operatorStack.Count > 0)
                    {
                        var abstractSyntaxTreeNode = operatorStack.Pop();
                        returnList.Add(abstractSyntaxTreeNode);
                    }
                    operatorStack.Push(item);
                }
                else if (item is GreaterThenNode || item is GreaterThenOrEqualNode ||
                    item is SmallerThenNode || item is SmallerThenOrEqualNode ||
                    item is EqualNode || item is UnEqualNode)
                {
                    if (operatorStack.Count() > 0 && (operatorStack.Peek() is MulNode || operatorStack.Peek() is DivNode ||
                        operatorStack.Peek() is ModuloNode))
                    {
                        AbstractSyntaxTreeNode node = operatorStack.Pop();
                        returnList.Add(node);
                    }
                    if (operatorStack.Count() > 0 && (operatorStack.Peek() is AddNode || operatorStack.Peek() is SubNode))
                    {
                        AbstractSyntaxTreeNode node = operatorStack.Pop();
                        returnList.Add(node);
                    }
                    operatorStack.Push(item);
                }
                else if (item is AddNode || item is SubNode)
                {
                    if (operatorStack.Count() > 0 && (operatorStack.Peek() is MulNode || operatorStack.Peek() is DivNode ||
                        operatorStack.Peek() is ModuloNode))
                    {
                        AbstractSyntaxTreeNode node = operatorStack.Pop();
                        returnList.Add(node);
                    }
                    operatorStack.Push(item);
                }
                else if (item is MulNode || item is DivNode || item is ModuloNode)
                {
                    operatorStack.Push(item);
                }
                position++;
            }
            while (operatorStack.Count > 0)
            {
                var abstractSyntaxTreeNode = operatorStack.Pop();
                returnList.Add(abstractSyntaxTreeNode);
            }
            return i;
        }
    }
}
