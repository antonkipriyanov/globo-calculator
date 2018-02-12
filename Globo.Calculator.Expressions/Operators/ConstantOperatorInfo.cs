namespace Globo.Calculator.Expressions.Operators
{
    public class ConstantOperatorInfo : OperatorInfo
    {
        public ConstantOperatorInfo(string value) : base(value)
        {
        }

        public override OperatorPrioity Prioity => OperatorPrioity.Low;

        public override OperatorType Type => OperatorType.Constant;

        public override Expression CreateExpression(ExpressionContext context)
        {
            return context.Right;
        }
    }
}