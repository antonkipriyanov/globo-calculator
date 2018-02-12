namespace Globo.Calculator.Host.Commands
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Expressions;
    using Globo.Commands.Commands;
    using Globo.Commands.Objects;
    using Globo.Commands.Results;
    using Serilog;

    public class EvaluateExpressionCommandHandler : CommandHandler<EvaluateExpressionCommand>
    {
        private readonly IExpressionBuilder builder;
        private readonly ILogger logger;
        private readonly IExpressionTransformer transformer;

        public EvaluateExpressionCommandHandler(EvaluateExpressionCommand command, IExpressionTransformer transformer, IExpressionBuilder builder, ILogger logger) : base(command)
        {
            this.transformer = transformer;
            this.builder = builder;
            this.logger = logger;
        }

        private string TransformedExpression { get; set; }

        protected override IEnumerable<IValidationError> Validate()
        {
            if (Command.Expression.NullOrWhiteSpace())
            {
                yield return new ValidationError("Expression should not be empty");
                yield break;
            }

            var errors = new List<ValidationError>();
            try
            {

                TransformedExpression = transformer.Transform(Command.Expression);
                logger.Debug("Transformed expression:{TransformedExpression}", TransformedExpression);
            }
            catch (Exception e)
            {
                logger.Debug(e, "An error occurred during expression transformation.");
                errors.Add(new ValidationError("Invalid expression. Please check all operators and paranthesis"));
            }

            foreach (var error in errors)
            {
                yield return error;
            }
        }

        protected override ExecutionResult ExecuteCore()
        {
            var expression = builder.Build(TransformedExpression);

            Command.Result = expression.Evaluate();

            return new ExecutionResult("Success");
        }
    }
}