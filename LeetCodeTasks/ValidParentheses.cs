namespace LeetCodeTasks
{
    public class ValidParentheses
    {
        public class Solution
        {

            private static Dictionary<char, char> pairs = new()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
            };

            private Stack<char> parenthesisStack = new();

            public bool IsValid(string inputString)
            {
                var currentOpenedParenthesis = char.MinValue;


                if (inputString.Length % 2 != 0)
                {
                    return false;
                }

                foreach (var symbol in inputString)
                {
                    if (symbol is '(' or '{' or '[')
                    {
                        if (currentOpenedParenthesis != char.MinValue)
                        {
                            parenthesisStack.Push(currentOpenedParenthesis);
                        }

                        currentOpenedParenthesis = symbol;
                    }
                    else
                    {
                        if (currentOpenedParenthesis == char.MinValue)
                        {
                            return false;
                        }

                        var expectedClosing = pairs[currentOpenedParenthesis];
                        if (expectedClosing != symbol)
                        {
                            return false;
                        }

                        currentOpenedParenthesis = parenthesisStack.Any() ? parenthesisStack.Pop() : char.MinValue;
                    }
                }

                return !parenthesisStack.Any();
            }
        }
    }
}
