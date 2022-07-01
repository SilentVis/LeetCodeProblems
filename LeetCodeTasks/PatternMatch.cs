namespace LeetCodeTasks
{
    public class PatternMatch
    {
        public class Solution
        {
            public bool IsMatch(string input, string pattern)
            {
                var pos = 0;
                var movements = 0;


                for (var i = 0; i < pattern.Length; i++)
                {
                    var currentRule = pattern[i].ToString();

                    if (i < pattern.Length - 1)
                    {
                        var next = pattern[i + 1];
                        if (next == '*')
                        {
                            currentRule += next;
                            i++;
                        }
                    }


                    if (currentRule.EndsWith("*"))
                    {
                        var target = currentRule.First();

                        if (pos < input.Length)
                        {
                            while (input[pos] == target || target == '.')
                            {
                                movements++;
                                pos++;

                                if (pos == input.Length)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    else if (currentRule == ".")
                    {
                        if (pos == input.Length)
                        {
                            if (movements == 0)
                            {
                                return false;
                            }
                            else
                            {
                                movements--;
                            }
                        }
                        else
                        {
                            pos++;
                        }
                    }
                    else
                    {
                        if (movements > 0)
                        {
                            var tst = pos;

                            while (movements >= 0)
                            {
                                if (tst < input.Length
                                    && input[tst] == currentRule[0])
                                {
                                    var subinput = input.Substring(tst);
                                    var subpatt = pattern.Substring(i);

                                    if (IsMatch(subinput, subpatt)) return true;
                                }

                                tst--;
                                movements--;
                            }

                            return false;
                        }
                        else
                        {
                            if (pos >= input.Length ||
                                input[pos] != currentRule[0])
                            {
                                return false;
                            }

                            pos++;
                        }

                    }
                }

                // Match entire string
                return pos == input.Length;
            }
        }
    }
}