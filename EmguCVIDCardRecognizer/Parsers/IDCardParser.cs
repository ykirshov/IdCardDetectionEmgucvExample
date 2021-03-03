using EmguCVIDCardRecognizer.Enums;
using EmguCVIDCardRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmguCVIDCardRecognizer.Parsers
{
    class IDCardParser
    {
        private static List<string> mrzStart = new List<string>
        {
            "IDUKR",
            "1DUKR",
            "IOUKR",
            "I0UKR",
            "1OUKR",
            "10UKR",
            "ID11KR",
            "IDU<R"
        };
        private static string patternNoise = @"[^A-Za-zА-Яа-я0-9<\r\n]";
        private static string patternCoretNoise = @"\r\n";

        public static IDCardClient ReadIDCardFrontSide(string data)
        {
            string patterIdCardNumber = @"[0-9]{9}";
            string patternRegisterRecordNumber = @"[0-9]{13}";
            string patternDate = @"[0-9]{8}";

            int indexFind = -1;
            int lengthFind = 0;

            IDCardClient client = new IDCardClient();

            Regex regexNoise = new Regex(patternNoise);
            data = regexNoise.Replace(data, "");
            regexNoise = new Regex(patternCoretNoise);
            data = regexNoise.Replace(data, "|");
            data = DigitParser.Parse(data);

            MatchCollection matchesDate = new Regex(patternDate).Matches(data);
            var tuple = SelectCorrectDateAndIndexes(matchesDate, DateType.BirthDate);
            if (tuple.date != null)
            {
                client.BirthDate = tuple.date;
                data = data.Remove(tuple.indexFind, tuple.lengthFind);
            }

            MatchCollection matchesCardsValidEnds = new Regex(patternDate).Matches(data);
            tuple = SelectCorrectDateAndIndexes(matchesCardsValidEnds, DateType.DateCardsValidEnds);
            if (tuple.date != null)
            {
                client.DateCardsValidEnds = tuple.date;
                data = data.Remove(tuple.indexFind, tuple.lengthFind);
            }

            MatchCollection matchesRegisterRecordNumber = new Regex(patternRegisterRecordNumber).Matches(data);
            if (matchesRegisterRecordNumber.Count > 0)
            {
                client.RegisterRecordNumber = matchesRegisterRecordNumber[0].Value.Insert(8, "-");
                indexFind = matchesRegisterRecordNumber[0].Index;
                lengthFind = client.RegisterRecordNumber.Length;

                data = data.Remove(indexFind, lengthFind);
            }

            MatchCollection matchesIdCardNumber = new Regex(patterIdCardNumber, RegexOptions.RightToLeft).Matches(data);
            if (matchesIdCardNumber.Count > 0)
            {
                client.IdCardNumber = matchesIdCardNumber[0].Value;
                indexFind = matchesIdCardNumber[0].Index;
                lengthFind = client.IdCardNumber.Length;

                data = data.Remove(indexFind, lengthFind);
            }
            return client;
        }

        public static IDCardClient ReadIDCardBackSide(string data)
        {
            IDCardClient client = new IDCardClient();
            Regex regexNoise = new Regex(patternNoise);
            data = regexNoise.Replace(data, "");
            regexNoise = new Regex(patternCoretNoise);
            data = regexNoise.Replace(data, "|");
            Console.WriteLine($"data = {data}");
            string info = "";
            string mrz = "";

            int indexStartMRZ = -1;
            foreach (var i in mrzStart)
            {
                indexStartMRZ = data.IndexOf(i);
                if (indexStartMRZ != -1)
                {
                    break;
                }
            }
            int indexFinishMRZ = data.LastIndexOf("<<");
            if (indexStartMRZ > -1 && indexFinishMRZ > -1)
            {
                info = data.Substring(0, indexStartMRZ);
                mrz = data.Substring(indexStartMRZ, indexFinishMRZ - indexStartMRZ);
            }
            else if (indexStartMRZ > -1)
            {
                info = data.Substring(0, indexStartMRZ);
                mrz = "";
            }
            else if (indexFinishMRZ > -1)
            {
                info = data.Substring(0, indexFinishMRZ - 60);
                mrz = data.Substring(indexFinishMRZ - 60, indexFinishMRZ);
            }

            client = MRZParser.Parse(mrz);

            var dictionary = ReadOtherInfoFromIDCardBackSide(info);
            string date = dictionary[$"{nameof(client.PassportDeliveryDate)}"];
            if (date != string.Empty)
            {
                client.PassportDeliveryDate = Convert.ToDateTime(dictionary[$"{nameof(client.PassportDeliveryDate)}"]);
            }
            else
            {
                client.PassportDeliveryDate = null;
            }

            client.PassportDeliveryBy = dictionary[$"{nameof(client.PassportDeliveryBy)}"];
            client.ClientInn = dictionary[$"{nameof(client.ClientInn)}"];
            return client;
        }

        private static Dictionary<string, string> ReadOtherInfoFromIDCardBackSide(string info)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            info = DigitParser.Parse(info);
            string deliveryBy = "";
            string clientInn = "";
            DateTime? deliveryDate = null;

            string patternDate = @"[0-9]{8}";
            string patternDelivery = @"[0-9]{4}";
            string patternInn = @"[0-9]{10}";

            int indexFind = 0;
            int lengthFind = 0;

            MatchCollection matchesDeliveryDate = new Regex(patternDate).Matches(info);
            var tuple = SelectCorrectDateAndIndexes(matchesDeliveryDate, DateType.PassportDeliveryDate);
            if (tuple.date != null)
            {
                deliveryDate = tuple.date;
                info = info.Remove(tuple.indexFind, tuple.lengthFind);
                info = info.Substring(tuple.indexFind);
            }

            MatchCollection matchesInn = new Regex(patternInn).Matches(info);
            if (matchesInn.Count > 0)
            {
                clientInn = matchesInn[0].Value;
                indexFind = matchesInn[0].Index;
                lengthFind = clientInn.Length;

                info = info.Remove(indexFind, lengthFind);
            }

            MatchCollection matchesDeliveryBy = new Regex(patternDelivery).Matches(info);
            if (matchesDeliveryBy.Count > 0)
            {
                deliveryBy = matchesDeliveryBy[0].Value;
            }
            result.Add("PassportDeliveryDate", deliveryDate.ToString());
            result.Add("PassportDeliveryBy", deliveryBy);
            result.Add("ClientInn", clientInn);
            return result;
        }
        private static DateTime? ParseDateTime(string date, DateType type)
        {
            DateTime? result = null;
            try
            {
                date = date.Insert(4, " ");
                date = date.Insert(2, " ");
                string[] dates = date.Split(' ');

                DateTime? dateCheck = new DateTime(Convert.ToInt32(dates[2]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[0]));
                switch (type)
                {
                    case DateType.BirthDate:
                        if (dateCheck <= DateTime.Now.AddYears(-14) && dateCheck >= DateTime.Now.AddYears(-100))
                        {
                            result = dateCheck;
                        }
                        break;
                    case DateType.DateCardsValidEnds:
                        if (dateCheck < DateTime.Now.AddYears(11) && dateCheck >= DateTime.Now)
                        {
                            result = dateCheck;
                        }
                        break;
                    case DateType.PassportDeliveryDate:
                        if (dateCheck <= DateTime.Now && dateCheck >= DateTime.Now.AddYears(-10))
                        {
                            result = dateCheck;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception) { }
            return result;
        }

        private static (DateTime? date, int indexFind, int lengthFind) SelectCorrectDateAndIndexes(MatchCollection matches, DateType type)
        {
            int indexFind = 0;
            int lengthFind = 0;
            DateTime? date = null;
            for (int i = 0; i < matches.Count; i++)
            {
                date = ParseDateTime(matches[i].Value, type);
                if (date != null)
                {
                    indexFind = matches[i].Index;
                    lengthFind = matches[i].Length;
                    break;
                }
            }
            return (date: date, indexFind: indexFind, lengthFind: lengthFind);
        }
    }
}
