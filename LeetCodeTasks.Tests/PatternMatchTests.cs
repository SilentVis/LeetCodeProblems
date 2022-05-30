using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class PatternMatchTests
    {
        private readonly PatternMatch.Solution _solution;

        public PatternMatchTests()
        {
            _solution = new PatternMatch.Solution();
        }

        [Theory]
        [InlineData("park","park")]
        [InlineData("park","par.")]
        [InlineData("park","....")]
        [InlineData("park","p*ark")]
        [InlineData("ark","p*ark")]
        [InlineData("aa","a*")]
        [InlineData("aa","a*.")]
        [InlineData("park", "p*a*park")]
        [InlineData("","p*a*")]
        [InlineData("paccrk", "pac*rk")]
        [InlineData("park", "p*.ark")]
        [InlineData("pcark", "p*.ark")]
        [InlineData("cark", "p*.ark")]
        [InlineData("ab", ".*")]
        [InlineData("aasdfasdfasdfasdfas", "aasdf.*asdf.*asdf.*asdf.*s")]
        [InlineData("aaa", "a*a")]

        public void ShouldMatch(string input, string pattern)
        {
            _solution.IsMatch(input, pattern).Should().BeTrue();
        }

        [Theory]
        [InlineData("park","parka")]
        [InlineData("park","par..")]
        [InlineData("park",".park")]
        [InlineData("park",".....")]
        [InlineData("pacacrk","pac*rk")]
        [InlineData("mississippi","mis*is*p*.")]
        [InlineData("a",".*..a*")]
        public void ShouldNotMatch(string input, string pattern)
        {
            _solution.IsMatch(input, pattern).Should().BeFalse();
        }
    }
}
