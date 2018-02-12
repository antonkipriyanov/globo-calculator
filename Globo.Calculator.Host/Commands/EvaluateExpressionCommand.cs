namespace Globo.Calculator.Host.Commands
{
    using Globo.Commands.Commands;

    public class EvaluateExpressionCommand : ICommand
    {
        public EvaluateExpressionCommand(string expression)
        {
            Expression = expression;
        }

        public string Expression { get; }

        public decimal Result { get; set; }
    }
}