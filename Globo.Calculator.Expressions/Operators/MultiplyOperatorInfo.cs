namespace Globo.Calculator.Expressions.Operators
{
    using System;

    public class MultiplyOperatorInfo : OperatorInfo
    {
        public MultiplyOperatorInfo(string value) : base(value)
        {
        }

        public override OperatorPrioity Prioity => OperatorPrioity.High;

        public override OperatorType Type => OperatorType.Operator;

        public override Expression CreateExpression(ExpressionContext context)
        {
            var del = new Func<decimal>(() => context.Left.Evaluate() * context.Right.Evaluate());

            return new Expression(del);
        }
    }
}