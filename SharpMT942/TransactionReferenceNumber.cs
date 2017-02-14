using System;

namespace SharpMT942
{
    public class TransactionReferenceNumber
    {

        public int TagNumber { get; } = 20;

        public string Format { get; }

        public string FormatCode { get; }

        public DateTime TransactionDateTime { get; set; }

        public TransactionReferenceNumber(string format, string formatCode, DateTime transactionDateTime)
        {
            Format = format;
            FormatCode = formatCode;
            TransactionDateTime = transactionDateTime;
        }
    }
}