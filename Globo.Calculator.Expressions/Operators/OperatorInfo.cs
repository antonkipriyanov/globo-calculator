namespace Globo.Calculator.Expressions.Operators
{
    public abstract class OperatorInfo
    {
        protected OperatorInfo(string value)
        {
            Value = value;
        }

        public abstract OperatorPrioity Prioity { get; }

        public abstract OperatorType Type { get; }

        public string Value { get; }

        public OperatorAssociationType OperatorAssociationType { get; set; }

        public abstract Expression CreateExpression(ExpressionContext context);

        public override string ToString()
        {
            return Value;
        }
    }
}