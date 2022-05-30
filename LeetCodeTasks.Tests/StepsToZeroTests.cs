using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class StepsToZeroTests
    {
        private readonly StepsToZero.Solution _solution;

        public StepsToZeroTests()
        {
            _solution = new StepsToZero.Solution();
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        [InlineData(14,6)]
        [InlineData(2,2)]
        public void ShouldCountCorrect(int input, int expected)
        {
            var result = _solution.NumberOfSteps(input);

            result.Should().Be(expected);
        }
    }
}
