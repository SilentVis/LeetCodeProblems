using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class IsPalindromeTests
    {

        private readonly Palindrome _palindrome;

        public IsPalindromeTests()
        {
            _palindrome = new Palindrome();
        }

        [Theory]
        [InlineData(121,true)]
        [InlineData(-121,false)]
        [InlineData(123,false)]
        [InlineData(10,false)]
        [InlineData(0,true)]
        [InlineData(1,true)]
        public void IsPalindrome_ShouldDetectCorrect(int number, bool expected)
        {
            _palindrome.IsPalindrome(number).Should().Be(expected);
        }
    }
}
