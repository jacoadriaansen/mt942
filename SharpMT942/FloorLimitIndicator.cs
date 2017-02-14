namespace SharpMT942
{
    public class FloorLimitIndicator
    {
        public decimal Amount { get; }

        public string Currency { get; }

        public FloorLimitIndicator(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}