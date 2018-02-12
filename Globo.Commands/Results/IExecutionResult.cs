namespace Globo.Commands.Results
{
    using System.Collections.Generic;

    public interface IExecutionResult
    {
        bool Success { get; }

        IEnumerable<string> Errors { get; set; }

        string Message { get; set; }
    }
}