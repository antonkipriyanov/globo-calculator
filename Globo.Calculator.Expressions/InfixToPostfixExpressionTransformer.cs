namespace Globo.Calculator.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Common;
    using Operators;

    public class InfixToPostfixExpressionTransformer : IExpressionTransformer
    {
        private const string OpenParenthesis = "(";
        private const string CloseParenthesis = ")";
        private const string Delimeter = " ";

        public string Transform(string input)
        {
            if (input.NullOrWhiteSpace())
            {
                throw new ArgumentNullException("input");
            }

            var stack = new Stack<OperatorInfo>();

            var result = new StringBuilder();

            var inputChars = Regex.Replace(input, @"\s+", "");

            foreach (var inputChar in inputChars)
            {
                var item = ArithmeticalOperatorFactory.Create(inputChar.ToString());

                if (item.Type == OperatorType.Operator)
                {
                    if (stack.Count > 0)
                    {
                        var topOperator = stack.Peek();

                        while ((item.OperatorAssociationType == OperatorAssociationType.Right && (int) item.Prioity < (int) topOperator.Prioity || item.OperatorAssociationType == OperatorAssociationType.Left && (int) item.Prioity <= (int) topOperator.Prioity) && stack.Count > 0)
                        {
                            AppendOperator(result, stack.Pop());

                            if (stack.Count > 0)
                            {
                                topOperator = stack.Peek();
                            }
                        }
                    }

                    stack.Push(item);

                    result.Append(Delimeter);
                    continue;
                }

                if (item.Value == OpenParenthesis)
                {
                    stack.Push(item);
                    continue;
                }

                if (item.Value == CloseParenthesis)
                {
                    var operatorInfo = stack.Pop();
                    while (operatorInfo.Value != OpenParenthesis && stack.Count != 0)
                    {
                        result.Append(Delimeter).Append(operatorInfo.Value);
                        operatorInfo = stack.Pop();
                    }

                    continue;
                }

                result.Append(inputChar);
            }

            AppendAllOperatorsFromStack(stack, result);

            return result.ToString().Trim();
        }

        private static void AppendAllOperatorsFromStack(IEnumerable<OperatorInfo> stack, StringBuilder result)
        {
            foreach (var operatorInfo in stack)
            {
                AppendOperator(result, operatorInfo);
            }
        }

        private static void AppendOperator(StringBuilder result, OperatorInfo operatorInfo)
        {
            result.Append(Delimeter).Append(operatorInfo.Value);
        }
    }
}