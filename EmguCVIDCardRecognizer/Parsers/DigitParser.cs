using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmguCVIDCardRecognizer.Parsers
{
    class DigitParser
    {
        private static Dictionary<string, string> _matchesDigit = new Dictionary<string, string>
        {
            ["’I"] = "1",
            ["O"] = "0",
            ["Z"] = "2",
            ["S"] = "5",
            ["%"] = "4",
            ["$"] = "3"
        };

        public static string Parse(string str)
        {
            string result = str;
            foreach (var i in _matchesDigit)
            {
                result = result.Replace(i.Key, i.Value);
            }
            return result;
        }
    }
}
