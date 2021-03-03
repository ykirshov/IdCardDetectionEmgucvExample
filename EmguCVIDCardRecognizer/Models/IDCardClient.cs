using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmguCVIDCardRecognizer.Models
{
    class IDCardClient
    {
        public string IdCardNumber { get; set; }

        public string RegisterRecordNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? DateCardsValidEnds { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientSex { get; set; }

        public string PassportDeliveryBy { get; set; }

        public DateTime? PassportDeliveryDate { get; set; }

        public string ClientInn { get; set; }

        public override string ToString()
        {
            return $"ClientFirstName = {ClientFirstName}\r\n" +
                   $"ClientLastName = {ClientLastName}\r\n" +
                   $"ClientSex = {ClientSex}\r\n" +
                   $"BirthDate = {BirthDate.ToString()}\r\n" +
                   $"DateCardValidEnds = {DateCardsValidEnds.ToString()}\r\n" +
                   $"RegisterRecordNumber = {RegisterRecordNumber}\r\n" +
                   $"IdCardNumber = {IdCardNumber}\r\n" +
                   $"PassportDeliveryBy = {PassportDeliveryBy}\r\n" +
                   $"PassportDeliveryDate = {PassportDeliveryDate.ToString()}\r\n" +
                   $"ClientInn = {ClientInn}";
        }

        public string ToStringFrontSide()
        {
            return $"BirthDate = {BirthDate.ToString()}\r\n" +
                   $"DateCardValidEnds = {DateCardsValidEnds.ToString()}\r\n" +
                   $"RegisterRecordNumber = {RegisterRecordNumber}\r\n" +
                   $"IdCardNumber = {IdCardNumber}\r\n";
        }
    }
}
