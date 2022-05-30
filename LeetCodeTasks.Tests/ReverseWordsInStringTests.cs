using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class ReverseWordsInStringTests
    {
        private readonly ReverseWordsInString.Solution _solution;

        public ReverseWordsInStringTests()
        {
            _solution = new ReverseWordsInString.Solution();
        }

        [Theory]
        [InlineData("hello", "hello")]
        [InlineData("hello world", "world hello")]
        [InlineData("   hello world  ", "world hello")]
        [InlineData("hello   world", "world hello")]
        public void ReverseWords_ShouldReverseWords(string input, string expectedOutput)
        {
            var result = _solution.ReverseWords(input);

            result.Should().Be(expectedOutput);
        }

    }
}
