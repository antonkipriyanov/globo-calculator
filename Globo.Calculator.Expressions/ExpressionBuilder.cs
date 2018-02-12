namespace Globo.Calculator.Expressions
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Operators;

    public class ExpressionBuilder : IExpressionBuilder
    {
        public Expression Build(string expression)
        {
            var stack = new Stack<Expression>();

            foreach (var item in expression.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
            {
                var operatorInfo = ArithmeticalOperatorFactory.Create(item);

                var context = new ExpressionContext();

                if (operatorInfo.Type == OperatorType.Constant)
                {
                    if (!decimal.TryParse(operatorInfo.Value, out var value))
                    {
                        throw new InvalidExpressionFormatException($"{operatorInfo.Value} is not a good value for operand.");
                    }

                    stack.Push(Expression.Constant(value));
                    continue;
                }

                if (operatorInfo.Type == OperatorType.Operator)
                {
                    context.Right = stack.Pop();
                    context.Left = stack.Pop();
                }

                var @operator = operatorInfo.CreateExpression(context);

                stack.Push(@operator);
            }

            if (stack.Count != 1)
            {
                throw new InvalidExpressionFormatException("Something wrong with your expression");
            }

            return stack.Pop();
        }
    }
}