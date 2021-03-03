using System;
using System.Text.RegularExpressions;

namespace EmguCVIDCardRecognizer.Parsers
{
    class FIOParser
    {
        private static string patternNameEng = @"[A-Z]{2,}";
        private static string patternNameUkr = @"[А-Я]{2,}";

        public static string ParseUkr(string data)
        {
            string result = "";
            MatchCollection matchesName = new Regex(patternNameUkr).Matches(data);
            if (matchesName.Count > 0)
            {
                result = matchesName[0].Value;
            }
            return result;
        }

        public static string ParseEng(string data)
        {
            string result = "";
            MatchCollection matchesName = new Regex(patternNameEng).Matches(data);
            if (matchesName.Count > 0)
            {
                result = matchesName[0].Value;
            }
            return result;
        }

    }
}
