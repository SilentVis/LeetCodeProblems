using System.IO.Compression;
using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using JetBrains.dotMemoryUnit;
using Xunit;
using Xunit.Abstractions;

namespace LeetCodeTasks.Tests
{
    public class ReverseStringTests
    {
        private readonly ReverseString.Solution _solution;

        public ReverseStringTests(ITestOutputHelper outputHelper)
        {
            _solution = new ReverseString.Solution();
            DotMemoryUnitTestOutput.SetOutputMethod(
                message => outputHelper.WriteLine(message));
        }

        [Theory]
        [InlineData("hello","olleh")]
        [InlineData("fish","hsif")]
        public void ReverseString_ShouldReverseObjects(string input, string expected)
        {
            var formattedInput = input.ToCharArray();
            var formattedExpected = expected.ToCharArray();

            _solution.ReverseString(formattedInput);

            formattedInput.Should().BeEquivalentTo(formattedExpected);
        }

        [Fact]
        public void ReverseString_ShouldNotCreateNewArray()
        {
            int preserve = 0;
            var input = "test".ToCharArray();
            dotMemory.Check(memory => preserve = memory.GetObjects(x => x.Type == typeof(char[])).ObjectsCount);
            
            _solution.ReverseString(input);

            //No new char arrays should be created 
            dotMemory.Check(memory => memory.GetObjects(x => x.Type == typeof(char[])).ObjectsCount.Should().BeLessOrEqualTo(preserve));
        }
    }
}
