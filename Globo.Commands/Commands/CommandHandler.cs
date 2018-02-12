namespace Globo.Commands.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Objects;
    using Results;

    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected CommandHandler(TCommand command)
        {
            Command = command;
        }

        protected TCommand Command { get; set; }

        public IExecutionResult Execute()
        {
            var validationResults = Validate().ToList();

            if (validationResults.Any())
            {
                return new ExecutionResult(validationResults)
                {
                    Message = "There are several validation errors."
                };
            }

            return ExecuteCore();
        }

        protected abstract IEnumerable<IValidationError> Validate();

        protected abstract ExecutionResult ExecuteCore();
    }
}