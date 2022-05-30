namespace LeetCodeTasks
{
    public class StepsToZero
    {
        public class Solution
        {
            public int NumberOfSteps(int num)
            {
                if (num != 0)
                {
                    return (int)Math.Log2(num) + Convert.ToString(num, 2).Count(c => c == '1');
                }

                return 0;
            }
        }
    }
}
