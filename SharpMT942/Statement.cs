using System;

namespace SharpMT942
{
    public class Statement 
    {
        public DateTime ValueDate { get; }
        public DateTime EntryDate { get; }
        public TransactionDirection DebitOrCredit { get; }
        public decimal Amount { get; }
        public TransactionType TransactionType { get; }
        public string CustomerReference { get; }
        public string BankReference { get; }
        public string SupplementaryDetails { get; }

        public Statement (DateTime valueDate, DateTime entryDate, TransactionDirection transactionDirection, decimal amount, TransactionType transactionType, string customerReference, string bankReference, string supplementaryDetails)
        {
            ValueDate = valueDate;
            EntryDate = entryDate;
            DebitOrCredit = transactionDirection;
            Amount = amount;
            TransactionType = transactionType;
            CustomerReference = customerReference;
            BankReference = bankReference;
            SupplementaryDetails = supplementaryDetails;
        }
    }
}