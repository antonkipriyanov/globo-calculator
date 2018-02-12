namespace Globo.Calculator.Expressions
{
    public interface IExpressionBuilder
    {
        Expression Build(string expression);
    }
}