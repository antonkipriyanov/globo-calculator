namespace Globo.Calculator.Expressions
{
    using System;

    public class Expression
    {
        private readonly Func<decimal> eval;

        public Expression(Func<decimal> eval)
        {
            this.eval = eval;
        }

        public static Expression Constant(decimal value)
        {
            return new Expression(() => value);
        }

        public decimal Evaluate()
        {
            return eval();
        }
    }
}