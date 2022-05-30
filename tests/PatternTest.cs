using FluentAssertions;
using PatternMatch;
using Xunit;

namespace tests
{
    public class PatternTest
    {
        MySolution solution = new MySolution();

        [Theory]
        [InlineData("park", "park")]
        [InlineData("park", "....")]
        [InlineData("park", "p..k")]
        [InlineData("park", "p*ark")]
        [InlineData("ark", "p*ark")]
        [InlineData("pppark", "p*ark")]
        [InlineData("pppark", "p*a.k")]
        [InlineData("rk", "p*a*.k")]
        [InlineData("", "p*a*")]


        public void PatternShouldMatch(string input, string pattern)
        {
            solution.IsMatch(input, pattern).Should().BeTrue();
        }

        [Theory]
        [InlineData("park", "parka")]
        [InlineData("park", ".....")]
        [InlineData("park", "p...k")]
        [InlineData("prk", "p*ark")]
        [InlineData("ppprk", "p*a.k")]
        [InlineData("", "p*a*.")]
        public void PatternShouldNotMatch(string input, string pattern)
        {
            solution.IsMatch(input, pattern).Should().BeFalse();
        }
    }
}