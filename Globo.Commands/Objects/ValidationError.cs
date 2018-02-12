namespace Globo.Commands.Objects
{
    public class ValidationError : IValidationError
    {
        public ValidationError(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}