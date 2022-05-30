namespace LeetCodeTasks
{
    public class AddTwoNumbers
    {
        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                var holder = new ListNode(0);
                var result = holder;

                var currentFirst = l1;
                var currentSecond = l2;

                var reserve = 0;

                while (currentFirst != null || currentSecond != null)
                {
                    var currentSum = 0;
                    
                    currentSum +=
                        (currentFirst?.val ?? 0) 
                        + (currentSecond?.val ?? 0)
                        + reserve;
                    reserve = 0;

                    result.next = new ListNode(currentSum % 10);
                    result = result.next;

                    if (currentSum >= 10)
                    {
                        reserve = 1;
                    }

                    currentFirst = currentFirst?.next;
                    currentSecond = currentSecond?.next;
                }

                if (reserve > 0)
                {
                    result.next = new ListNode(1);
                }

                return holder.next;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode? next;

            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }


}
