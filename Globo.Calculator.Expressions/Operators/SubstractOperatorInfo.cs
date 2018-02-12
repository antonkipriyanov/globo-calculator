namespace Globo.Calculator.Expressions.Operators
{
    using System;

    public class SubstractOperatorInfo : OperatorInfo
    {
        public SubstractOperatorInfo(string value) : base(value)
        {
        }

        public override OperatorPrioity Prioity => OperatorPrioity.Normal;

        public override OperatorType Type => OperatorType.Operator;

        public override Expression CreateExpression(ExpressionContext context)
        {
            var del = new Func<decimal>(() => context.Left.Evaluate() - context.Right.Evaluate());

            return new Expression(del);
        }
    }
}