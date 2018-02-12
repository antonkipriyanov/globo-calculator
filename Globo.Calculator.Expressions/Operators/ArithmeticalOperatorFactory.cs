namespace Globo.Calculator.Expressions.Operators
{
    public class ArithmeticalOperatorFactory
    {
        public static OperatorInfo Create(string s)
        {
            switch (s)
            {
                case "+":
                    return new AddOperatorInfo(s);
                case "-":
                    return new SubstractOperatorInfo(s);
                case "*":
                    return new MultiplyOperatorInfo(s);
                case "/":
                    return new DivideOperatorInfo(s);
                default:
                    return new ConstantOperatorInfo(s);
            }
        }
    }
}