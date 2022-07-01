namespace LeetCodeTasks
{
    public class Palindrome
    {
        public bool IsPalindrome(int number)
        {
            switch (number)
            {
                case < 0:
                    return false;
                case < 10:
                    return true;
            }

            var reversed = 0;
            var reserved = number;

            while (reserved > 0)
            {
                reversed *= 10;
                var digit = reserved % 10;

                reversed += digit;

                reserved -= digit;
                reserved /= 10;
            }

            return number == reversed;
        }

    }
}
