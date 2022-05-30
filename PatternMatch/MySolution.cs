namespace PatternMatch
{
    public class MySolution
    {
        public bool IsMatch(string s, string p)
        {
            if (p.Length == 1 && char.IsLetter(p[0]) && char.IsUpper(p[0]))
            {
                var tgtPat = p.ToLower();
                return string.IsNullOrEmpty(s) || s.All(c => c == tgtPat[0]);
            }

            // no dots and asterisk - exact match
            if (!p.Contains(".") && !p.Contains("*"))
            {
                return s == p;
            }

            // no asterisk - char-by-char ckip dots
            if (!p.Contains('*'))
            {
                if (p.Length != s.Length) { return false; }

                for (int i = 0; i < s.Length; i++)
                {
                    if (p[i] != '.' && s[i] != p[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            string pat = "";
            for(int i = 0; i < p.Length; i++)
            {
                if (char.IsLetter(p[i]) && i < p.Length - 1)
                {
                    if (p[i+1] == '*')
                    {
                        pat += p[i].ToString().ToUpper();
                        i++;
                        continue;
                    }
                    else
                    {
                        pat += p[i];
                    }
                }
                else
                {
                    pat += p[i];
                }
            }

            var dots = pat.Count(c=>c == '.');


            if (!pat.Any(c => char.IsLower(c)))
            {
                var lowered = pat.ToLower();
                var j = 0;

                for (int i = 0; i < lowered.Length; i++)
                {
                    var symb = lowered[i];
                    char next = '-';
                    if(i <lowered.Length - 1)
                    {
                        next = lowered[i+1];
                    }

                    if (s[j] != symb)
                    {
                        if(s[j] != next) return false;
                    }
                    j++;
                }
            }



            var let = pat.FirstOrDefault(char.IsLower);
            var firstLetterIndex = pat.IndexOf(let);

            var letter = pat[firstLetterIndex];
            var letterIndexInTgt = s.IndexOf(letter);

            if (letterIndexInTgt == -1) return false;

            var prePattern = pat.Substring(0, firstLetterIndex);
            var postPattern = pat.Substring(firstLetterIndex + 1);

            var preString = s.Substring(0, letterIndexInTgt);
            var postString = s.Substring(letterIndexInTgt + 1);


            var match = IsMatch(preString, prePattern) && IsMatch(postString, postPattern);

            return true;
        }

        //public bool IsMatch(string s, string p)
        //{
        //    // all allowed
        //    if (p == "*")
        //    {
        //        return true;
        //    }

        //    // only dots and asterisk - just count
        //    if(p.All(c => c == '.' || c == '*'))
        //    {
        //        return s.Length >= p.Count(c => c == '.');
        //    }

        //    // no dots and asterisk - exact match
        //    if (!p.Contains(".") && !p.Contains("*"))
        //    {
        //        return s == p;
        //    }

        //    // no asterisk - char-by-char ckip dots
        //    if (!p.Contains('*'))
        //    {
        //        if (p.Length != s.Length) { return false; }

        //        for (int i = 0; i < s.Length; i++)
        //        {
        //            if (p[i] != '.' && s[i] != p[i])
        //            { 
        //                return false; 
        //            }
        //        }

        //        return true;
        //    }


        //    var firstLetterIndex = p.IndexOf(p.First(char.IsLetter));

        //    var letter = p[firstLetterIndex];
        //    var letterIndexInTgt = s.IndexOf(letter);

        //    if (letterIndexInTgt == -1) return false;

        //    var prePattern = p.Substring(0, firstLetterIndex);
        //    var postPattern = p.Substring(firstLetterIndex + 1);

        //    var preString = s.Substring(0, letterIndexInTgt);
        //    var postString = s.Substring(letterIndexInTgt + 1);

        //    var match = IsMatch(preString, prePattern) && IsMatch(postString, postPattern);

        //    return match;
        //}
    }
}
