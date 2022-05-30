namespace LeetCodeTasks
{
    public class ReverseWordsInString
    {
        public class Solution
        {
            public string ReverseWords(string s)
            {
                var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                ReverseArray(words);

                return string.Join(' ', words);
            }

            private void ReverseArray(string[] words)
            {
                var left = 0;
                for (var right = words.Length - 1; left <= right; left++, right--)
                {
                    (words[left], words[right]) = (words[right], words[left]);
                }
            }
        }
    }
}
