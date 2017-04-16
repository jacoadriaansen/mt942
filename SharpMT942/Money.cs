namespace SharpMT942
{
    public class Money
    {
        public decimal Amount { get; }

        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected bool Equals(Money other)
        {
            if(other == null)
            {
                return false;
            }

            return Amount == other.Amount && string.Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (Currency?.GetHashCode() ?? 0);
            }
        }
    }
}