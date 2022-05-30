using System;
using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class AddTwoNumbersTests
    {
        private readonly AddTwoNumbers.Solution _solution;

        public AddTwoNumbersTests()
        {
            _solution = new AddTwoNumbers.Solution();
        }

        [Theory]
        [InlineData(100, 200, 300)]
        [InlineData(150,250, 400)]
        [InlineData(100, 1, 101)]
        [InlineData(101, 9, 110)]
        [InlineData(342, 465, 807)]
        [InlineData(9999999, 9999, 10009998)]
        public void ShouldAddCorrectly(long first, long second, long expected)
        {
            var l1 = NumberToNode(first);
            var l2 = NumberToNode(second);

            var result = _solution.AddTwoNumbers(l1, l2);

            NodeToInt(result).Should().Be(expected);
        }

        private AddTwoNumbers.ListNode NumberToNode(long number)
        {
            var str = number.ToString();

            AddTwoNumbers.ListNode result = null;

            foreach (var ch in str)
            {
                var numb = int.Parse(ch.ToString());

                result = new AddTwoNumbers.ListNode(numb, result);
            }

            return result;
        }

        private long NodeToInt(AddTwoNumbers.ListNode number)
        {
            var pow = 0;

            long result = 0;

            while (number != null)
            {
                if (number.val != 0)
                {
                    result += (long) Math.Pow(10, pow) * number.val;
                }

                pow++;
                number = number.next;
            }

            return result;
        }

    }
}
