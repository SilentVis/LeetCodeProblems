using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace LeetCodeTasks.Tests
{
    public class SortedArraySearchTests
    {
        [Fact]
        public void ttt()
        {
            var arr = new int[] { -1, 0, 3, 5, 9, 12 };
            var reader = new SortedArraySeach.ArrayReader(arr);

            var t = new SortedArraySeach().Search(reader, 9).Should().Be(4);
        }
    }
}
