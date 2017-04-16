using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag28CParserTests
    {
        [Fact]
        public void TransactionStatementNumber() 
        {
            var transactionStatementNumber = Tag28CParser.Parse(":28c:12345/35467");

            var expectedTransactionStatementNumber = new TransactionStatementNumber(12345, 35467);
            Assert.Equal(expectedTransactionStatementNumber, transactionStatementNumber);
        }

         [Fact]
        public void OptionalSequenceNumberParser() 
        {            
            var transactionStatementNumber = Tag28CParser.Parse(":28c:12345");

            var expectedTransactionStatementNumber = new TransactionStatementNumber(12345);

            Assert.Equal(expectedTransactionStatementNumber, transactionStatementNumber);
        }
    }

        
}