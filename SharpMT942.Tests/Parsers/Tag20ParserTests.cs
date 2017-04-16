using System;
using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag20ParserTests
    {
        [Fact]
        public void TransactionReferenceNumber()
        { 
            var transactionReferenceNumber = Tag20Parser.Parse(":20:942S161226095110");

            var expectedTransactionReferenceNumber = new TransactionReferenceNumber
            (
                "942", 
                "S", 
                new DateTime(2016, 12, 26, 09, 51, 10)
            );

            Assert.Equal(expectedTransactionReferenceNumber, transactionReferenceNumber);
        }
    }        
}