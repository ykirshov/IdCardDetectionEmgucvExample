using System;
using System.Text.RegularExpressions;

namespace EmguCVIDCardRecognizer.Parsers
{
    class INNParser
    {
        private static string patternInn = @"[0-9]{10}";

        public static string Parse(string info)
        {
            string result = "";

            MatchCollection matchesInn = new Regex(patternInn).Matches(info);
            if (matchesInn.Count > 0)
            {
                result = matchesInn[0].Value;
            }
            return result;
        }
    }
}
