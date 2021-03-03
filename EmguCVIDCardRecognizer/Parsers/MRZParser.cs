using EmguCVIDCardRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmguCVIDCardRecognizer.Parsers
{
    class MRZParser
    {
        private static Dictionary<string, string> _matchesMRZData = new Dictionary<string, string>
        {
            ["I"] = "1",
            ["I"] = "1",
            ["O"] = "0",
            ["Z"] = "2",
            ["S"] = "5",
            ["r4"] = "M",
            ["D"] = "0",
            ["/"] = "",
            ["l"] = "1",
            ["|"] = "",
            ["v"] = ""
        };

        private static Dictionary<string, string> _matchesMRZName = new Dictionary<string, string>
        {
            ["0"] = "O",
            ["1"] = "I",
            ["<"] = "K",
            ["3"] = "",
            ["5"] = "S",
            ["2"] = "Z",
            ["|"] = ""
        };
        private static string patternNoise = @"[a-z]";

        public static string CheckErrors(string mrz)
        {
            string result = mrz.Substring(0, 5);
            string strCheck = mrz.Substring(5, 55);
            foreach (var i in _matchesMRZData)
            {
                strCheck = strCheck.Replace(i.Key, i.Value);
            }
            result += strCheck + mrz.Substring(60);
            Regex regexNoise = new Regex(patternNoise);
            result = regexNoise.Replace(result, "");
            return result;
        }

        public static IDCardClient Parse(string mrz)
        {
            IDCardClient client = new IDCardClient();
            if (mrz.Length > 50)
            {
                mrz = mrz.Replace("\r\n", "");
                string mrzClean = mrz;
                try
                {
                    mrzClean = CheckErrors(mrz);
                }
                catch (Exception) { }

                client.ClientSex = GetClientSex(mrzClean);
                client.ClientFirstName = GetClientFirstName(mrzClean);
                client.ClientLastName = GetClientLastName(mrzClean);
                client.BirthDate = GetBirthDate(mrzClean);
                client.DateCardsValidEnds = GetDateCardsValidEnds(mrzClean);
                client.RegisterRecordNumber = GetRegisterRecordNumber(mrzClean);
                client.IdCardNumber = GetIdCardNumber(mrzClean);
            }
            return client;
        }

        public static string GetIdCardNumber(string mrz)
        {
            string result = null;
            try
            {
                result = mrz.Substring(5, 9);
            }
            catch (Exception) { }
            return result;
        }

        public static string GetRegisterRecordNumber(string mrz)
        {
            string result = null;
            try
            {
                result = mrz.Substring(15, 13).Insert(8, "-");
            }
            catch (Exception) { }
            return result;
        }

        public static DateTime? GetBirthDate(string mrz)
        {
            DateTime? result = null;
            try
            {
                string date = mrz.Substring(30, 6);
                int year = DateTime.Now.Year - 2000;
                int razn = year - Convert.ToInt32(date.Substring(0, 2));
                int startYear = 0;
                if (razn < 14)
                {
                    startYear = 1900;
                }
                else
                {
                    startYear = 2000;
                }
                result = new DateTime(startYear + Convert.ToInt32(date.Substring(0, 2)), Convert.ToInt32(date.Substring(2, 2)), Convert.ToInt32(date.Substring(4, 2)));
            }
            catch (Exception) { }
            return result;
        }

        public static DateTime? GetDateCardsValidEnds(string mrz)
        {
            DateTime? result = null;
            try
            {
                string date = mrz.Substring(38, 6);
                result = new DateTime(2000 + Convert.ToInt32(date.Substring(0, 2)), Convert.ToInt32(date.Substring(2, 2)), Convert.ToInt32(date.Substring(4, 2)));
            }
            catch (Exception) { }
            return result;
        }

        public static string GetClientSex(string mrz)
        {
            string result = null;
            try
            {
                result = mrz.Substring(37, 1);
            }
            catch (Exception) { }
            return result;
        }

        public static string GetClientFirstName(string mrz)
        {
            string result = null;
            try
            {
                result = mrz.Substring(60).Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries)[0];
                foreach (var i in _matchesMRZName)
                {
                    result = result.Replace(i.Key, i.Value);
                }
            }
            catch (Exception) { }
            return result;
        }

        public static string GetClientLastName(string mrz)
        {
            string result = null;
            try
            {
                result = mrz.Substring(60).Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries)[1];
                foreach (var i in _matchesMRZName)
                {
                    result = result.Replace(i.Key, i.Value);
                }
            }
            catch (Exception) { }
            return result;
        }
    }
}
