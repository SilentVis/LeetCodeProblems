using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class ValidParenthesesTests
    {
        private ValidParentheses.Solution _solution;


        public ValidParenthesesTests()
        {
            _solution = new ValidParentheses.Solution();
        }

        [Theory]
        [InlineData("{}",true)]
        [InlineData("()",true)]
        [InlineData("[]",true)]
        [InlineData("{}()[]",true)]
        [InlineData("{([])}",true)]
        [InlineData("{(})",false)]
        [InlineData("[",false)]
        [InlineData("((",false)]
        [InlineData("){",false)]
        public void IsValid_ShouldReturnCorrectResult(string input, bool expectedResult)
        {
            var actualResult = _solution.IsValid(input);

            actualResult.Should().Be(expectedResult);
        }
    }
}
