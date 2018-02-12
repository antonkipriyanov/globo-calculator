namespace Globo.Calculator.Expressions.Exceptions
{
    using System;

    public class InvalidExpressionFormatException : Exception
    {
        public InvalidExpressionFormatException(string message) : base(message)
        {
        }
    }
}