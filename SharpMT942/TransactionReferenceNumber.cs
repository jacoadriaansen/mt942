using System;

namespace SharpMT942
{
    public class TransactionReferenceNumber
    {
        public string Format { get; }

        public string FormatCode { get; }

        public DateTime TransactionDateTime { get; set; }

        public TransactionReferenceNumber(string format, string formatCode, DateTime transactionDateTime)
        {
            Format = format;
            FormatCode = formatCode;
            TransactionDateTime = transactionDateTime;
        }

        protected bool Equals(TransactionReferenceNumber other)
        {
            if( other == null)
            {
                return false;
            }

            return string.Equals(Format, other.Format) && string.Equals(FormatCode, other.FormatCode) && TransactionDateTime.Equals(other.TransactionDateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TransactionReferenceNumber) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Format?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (FormatCode?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ TransactionDateTime.GetHashCode();
                return hashCode;
            }
        }
    }
}