namespace Globo.Calculator.Expressions.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class ExpressionTransformerTests
    {
        private readonly InfixToPostfixExpressionTransformer expressionsTransformer;

        public ExpressionTransformerTests()
        {
            expressionsTransformer = new InfixToPostfixExpressionTransformer();
        }

        [Theory]
        [InlineData("1+4", "1 4 +")]
        [InlineData("1*4", "1 4 *")]
        [InlineData("1-4", "1 4 -")]
        [InlineData("1/4", "1 4 /")]
        public void ShouldReturnCorrectExpressionForRegisteredOperators(string input, string expected)
        {
            var result = expressionsTransformer.Transform(input);

            result.ShouldBe(expected);
        }

        [Fact]
        public void ShouldThrowInvalidExpressionFormatExceptionWhenInvalidOperand()
        {
            var result = "";
            Should.NotThrow(() => result = expressionsTransformer.Transform("asd + 5"));

            result.ShouldBe("asd 5 +");
        }

        [Fact]
        public void ShouldCorrectHandleOperatorPriority()
        {
            var result = expressionsTransformer.Transform("1 + 5 * 2");

            result.ShouldBe("1 5 2 * +");
        }

        [Fact]
        public void ShouldCorrectHandleOperatorPriorityWithParenthesisAtTheBeginning()
        {
            var result = expressionsTransformer.Transform("(1 + 5) * 2");

            result.ShouldBe("1 5 + 2 *");
        }

        [Fact]
        public void ShouldCorrectHandleOperatorPriorityWithParenthesisAtTheEnd()
        {
            var result = expressionsTransformer.Transform("7 * (3 - 5)");

            result.ShouldBe("7 3 5 - *");
        }

        [Fact]
        public void ShouldIgnoreSpaces()
        {
            var result = expressionsTransformer.Transform("(                      1+               5          )                 *                   2");

            result.ShouldBe("1 5 + 2 *");
        }

        [Fact]
        public void ShouldThrowAgumentNullExceptionForEmptyInput()
        {
            Should.Throw<ArgumentNullException>(() => expressionsTransformer.Transform(""));
        }

        [Fact]
        public void ShouldBeNoParanthesisInResult()
        {
            var result = expressionsTransformer.Transform("(((( 1 + ((5))))))");

            result.ShouldBe("1 5 +");
        }
    }
}