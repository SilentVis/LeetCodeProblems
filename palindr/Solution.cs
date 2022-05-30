public class MySol
{
    public bool IsMatch(string target, string pattern)
    {
        // task - find a part of the string that match the pattern 
        // strict rule - pattern neither * nor .
        // . - length limit
        // * - no limits

        // tgt: "somestring"  --> some  str     i   n   g
        // pattern: "*str.n." --> *     str     .   n   . 

        // split pattern into rules, find first strict one, 
        var rules = SplitIntoRules(pattern);

        RunRules(target, rules, RuleType.Strict);
        RunRules(target, rules, RuleType.Dot);
        RunRules(target, rules, RuleType.Asterisk);

        var x = 10;

        return true;

    }

    private void RunRules(string tgt, List<IRule> rules, RuleType rulesToRun)
    {
        for(int i = 0; i < rules.Count; i++)
        {
            var rule = rules[i];

            if(rule.Type == rulesToRun)
            {
                rule.Run(tgt);
            }
        }
    }

    private interface IRule
    {
        RuleType Type { get; }

        void Run(string tgt);
    }

    private enum RuleType
    {
        Strict = 0,
        Dot = 1,
        Asterisk,
    }

    private class Rule : IRule
    {
        public Rule(RuleType type, Rule? prevRule)
        {
            _previousRule = prevRule;
            Type = type;
            StartIndex = -1;
            EndIndex = -1;
        }

        public int StartIndex;

        public int EndIndex;

        private Rule? _previousRule;

        private Rule? _nextRule;

        public RuleType Type { get; set; }


        public void SetNextRule(Rule rule)
        {
            _nextRule = rule;
        }

        public int FindPreviousBusyIndex() => EndIndex != -1 ? EndIndex : _previousRule != null ? _previousRule.FindPreviousBusyIndex() : EndIndex;

        public int FindNextBusyIndex() => StartIndex != -1 ? StartIndex : _nextRule != null ? _nextRule.FindNextBusyIndex() : StartIndex;

        public void Run(string tgt)
        {
            var previousIndex = FindPreviousBusyIndex();
            var nextIndex = FindNextBusyIndex();

            var leftIsFree = previousIndex == -1;
            var rightIsFree = nextIndex == -1;

            if (Type == RuleType.Dot)
            {
                if (tgt.Length == 0) return;

                if (leftIsFree && rightIsFree) //No limits which index to get
                {
                    StartIndex = EndIndex = 0;
                }

                if (!leftIsFree && rightIsFree) //Some rules took symbols left
                {
                    StartIndex = EndIndex = previousIndex + 1;
                }

                if (leftIsFree && !rightIsFree) //Some rules took symbols right
                {
                    StartIndex = EndIndex = nextIndex - 1;
                }

                if (!leftIsFree && !rightIsFree) // there are rules both sides -> stick to the left part if there is free index
                {
                    if (Math.Abs(nextIndex - previousIndex) > 1)
                    {
                        StartIndex = EndIndex = previousIndex + 1;
                    }
                }
            }
            else // asterisk
            {
                if (tgt.Length == 0) return;

                if (leftIsFree && rightIsFree) //No limits which index to get
                {
                    StartIndex = 0;
                    EndIndex = tgt.Length - 1;
                }

                if (!leftIsFree && rightIsFree) //Some rules took symbols left
                {
                    StartIndex = previousIndex + 1;
                    EndIndex = tgt.Length - 1;
                }

                if (leftIsFree && !rightIsFree) //Some rules took symbols right
                {
                    StartIndex = 0;
                    EndIndex = nextIndex - 1;
                }

                if (!leftIsFree && !rightIsFree) // there are rules both sides -> stick to the left part if there is free index
                {
                    if (Math.Abs(nextIndex - previousIndex) > 0)
                    {
                        StartIndex = previousIndex + 1;
                        EndIndex = nextIndex - 1;
                    }
                }
            }
        }

    }

    private class StrictRule : Rule, IRule
    {
        public StrictRule(string pattern, Rule? previousRule) : base(RuleType.Strict, previousRule)
        {
            Pattern = pattern;
        }

        public string Pattern;

        public void Run(string tgt)
        {
            var previousIndex = FindPreviousBusyIndex();
            var nextIndex = FindNextBusyIndex();

            string part = "";
            if (previousIndex != -1 || nextIndex != -1)
            {
                var st = Math.Max(previousIndex, 0);

                part = tgt.Substring(st, nextIndex != -1 ? (nextIndex - st) : (tgt.Length - st));
            }
            else
            {
                part = tgt;
            }

            var index = part.IndexOf(Pattern, StringComparison.Ordinal);

            if (index != -1)
            {
                StartIndex = index + (previousIndex != -1? previousIndex : 0);
                EndIndex = StartIndex + Pattern.Length;
            }
        }
    }

    private List<IRule> SplitIntoRules(string pattern)
    {
        var rules = new List<IRule>();
        string subPattern = "";
        Rule? lastAddedRule = null;

        for (int i = 0; i < pattern.Length; i++)
        {
            var c = pattern[i];
            if (char.IsLetterOrDigit(c))
            {
                subPattern += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(subPattern))
                {
                    AddRule(rules, ref lastAddedRule, CreateStrictRule(subPattern, lastAddedRule));
                    subPattern = "";
                }

                if (c == '.') AddRule(rules, ref lastAddedRule, CreateRule(RuleType.Dot, lastAddedRule));
                else AddRule(rules, ref lastAddedRule, CreateRule(RuleType.Asterisk, lastAddedRule));
            }

        }

        if (!string.IsNullOrEmpty(subPattern)) AddRule(rules, ref lastAddedRule, CreateStrictRule(subPattern, lastAddedRule));

        return rules;
    }

    private void AddRule(List<IRule> rules, ref Rule? lastAddedRule, Rule newRule)
    {
        if (lastAddedRule != null)
            lastAddedRule.SetNextRule(newRule);
        lastAddedRule = newRule;

        rules.Add(newRule);
    }

    private Rule CreateRule(RuleType type, Rule? lastRule) => new Rule(type, lastRule);

    private Rule CreateStrictRule(string pattern, Rule? lastRule) => new StrictRule(pattern, lastRule);
}