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


//if (!pattern.Contains('*'))
            //{
            //    if (pattern.Length != input.Length) return false;

            //    if (!pattern.Contains('.')) return pattern == input;

            //    for (var i = 0; i < input.Length; i++)
            //    {
            //        if (pattern[i] != '.' && pattern[i] != input[i]) return false;
            //    }
            //}
            //else
            //{
            //    var rules = SplitPattern(pattern);




            //    var pos = 0;
            //    var eos = pos == input.Length;
            //    var movements = 0;

            //    for (var r = 0; r < rules.Count; r++)
            //    {
            //        var rule = rules[r];
            //        if (rule == ".")
            //        {
            //            if (!RunDot(eos, ref movements, ref pos)) return false;
            //        }
            //        else if (rule.Length == 2)
            //        {
            //            pos = RunAsterisk(input, rule, eos, pos, ref movements);
            //        }
            //        else
            //        {
            //            var tst = pos;
            //            if (movements > 0)
            //            {
            //                while (movements > 0)
            //                {
            //                    if (input[tst] == rule[0] && IsMatch(input.Substring(tst),string.Join(rules.)))
            //                    {
            //                        pos = tst;
            //                        break;
            //                    }

            //                    tst--;
            //                    movements--;
            //                }

            //                eos = pos == input.Length;

            //            }

            //            if (eos || input[pos] != rule[0]) return false;

            //            movements = 0;
            //            pos++;
            //        }

            //        eos = pos == input.Length;
            //    }

            //    if (pos != input.Length) return false;
            //}

            //return true;
        //}

    //    private static int RunAsterisk(string input, string rule, bool eos, int pos, ref int movements)
    //    {
    //        var targetSymb = rule[0];

    //        if (!eos)
    //        {
    //            while (input[pos] == targetSymb || targetSymb == '.')
    //            {
    //                movements++;
    //                pos++;
    //                if (pos == input.Length) break;
    //            }
    //        }

    //        return pos;
    //    }

    //    private static bool RunDot(bool eos, ref int movements, ref int pos)
    //    {
    //        if (eos)
    //        {
    //            if (movements == 0)
    //                return false;
    //            movements--;
    //        }
    //        else
    //        {
    //            pos++;
    //        }

    //        return true;
    //    }

    //    private List<string> SplitPattern(string pattern)
    //    {
    //        var res = new List<string>();

    //        for (int i = 0; i < pattern.Length; i++)
    //        {
    //            var current = pattern[i].ToString();
    //            if (i != pattern.Length - 1)
    //            {
    //                var next = pattern[i + 1];
    //                if (next == '*')
    //                {
    //                    i++;
    //                    current += next;
    //                }
    //            }

    //            res.Add(current);

    //        }

    //        return res;
    //    }
    //}
//}
//}
