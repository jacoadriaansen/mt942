namespace SharpMT942
{
    public static class TransactionTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Msc")]
        public static TransactionType Msc { get; } = new TransactionType("MSC", "Name");
    }
}