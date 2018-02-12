namespace Globo.Commands.Results
{
    using System.Collections.Generic;
    using System.Linq;
    using Objects;

    public class ExecutionResult : IExecutionResult
    {
        public ExecutionResult(IEnumerable<IValidationError> validationResults)
        {
            Errors = validationResults.Select(x => x.Message);
        }

        public ExecutionResult(string message)
        {
            Message = message;
        }

        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public bool Success => !Errors.Any();

        public string Message { get; set; }
    }
}