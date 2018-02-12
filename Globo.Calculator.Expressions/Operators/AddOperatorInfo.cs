namespace Globo.Calculator.Expressions.Operators
{
    using System;

    public class AddOperatorInfo : OperatorInfo
    {
        public AddOperatorInfo(string value) : base(value)
        {
        }

        public override OperatorPrioity Prioity => OperatorPrioity.Normal;

        public override OperatorType Type => OperatorType.Operator;

        public override Expression CreateExpression(ExpressionContext context)
        {
            var del = new Func<decimal>(() => context.Left.Evaluate() + context.Right.Evaluate());

            return new Expression(del);
        }
    }
}