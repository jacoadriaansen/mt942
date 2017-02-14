using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag28cParserTests
    {
        [Fact]
        public void BasicParser() 
        {
            var tag28cParser = new Tag28CParser();
            
            var transactionStatementNumber = tag28cParser.Parse(":28c:12345/35467");
    
            Assert.Equal(12345, transactionStatementNumber.StatementNumber);
            Assert.Equal(35467, transactionStatementNumber.SequenceNumber);
        }

         [Fact]
        public void OptionalSequenceNumberParser() 
        {
            var tag28cParser = new Tag28CParser();
            
            var transactionStatementNumber = tag28cParser.Parse(":28c:12345");
    
            Assert.Equal(12345, transactionStatementNumber.StatementNumber);
            Assert.Equal(null, transactionStatementNumber.SequenceNumber);
        }
    }

        
}