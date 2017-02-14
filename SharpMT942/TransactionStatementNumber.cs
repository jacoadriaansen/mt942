namespace SharpMT942
{
    public class TransactionStatementNumber
    {
        public int StatementNumber { get; }
        public int? SequenceNumber { get; }

        public TransactionStatementNumber(int statementNumber, int? sequenceNumber)
        {
            StatementNumber = statementNumber;
            SequenceNumber = sequenceNumber;
        }
    }
}