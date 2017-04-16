namespace SharpMT942
{
    public class TransactionStatementNumber
    {
        public int StatementNumber { get; }
        public int? SequenceNumber { get; }

        public TransactionStatementNumber(int statementNumber)
            : this(statementNumber, null)
        {
        }

        public TransactionStatementNumber(int statementNumber, int? sequenceNumber)
        {
            StatementNumber = statementNumber;
            SequenceNumber = sequenceNumber;
        }

        protected bool Equals(TransactionStatementNumber other)
        {
            if(other == null)
            {
                return false;
            }

            return StatementNumber == other.StatementNumber && SequenceNumber == other.SequenceNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TransactionStatementNumber) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StatementNumber * 397) ^ SequenceNumber.GetHashCode();
            }
        }
    }
}