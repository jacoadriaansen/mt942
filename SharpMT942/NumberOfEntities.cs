namespace SharpMT942.Parsers
{
    public class NumberOfEntitiesTransactionReport
    {
        public int NumberOfEntities { get; }
        public Money Amount { get; }

        public NumberOfEntitiesTransactionReport(int numberOfEntities, Money totalAmount)
        {
            NumberOfEntities = numberOfEntities;
            Amount = totalAmount;
        }
    }
}