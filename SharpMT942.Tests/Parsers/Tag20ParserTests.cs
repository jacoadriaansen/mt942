using System;
using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag20ParserTests
    {
        [Fact]
        public void BasicParser() 
        {
            var tag20Parser = new Tag20Parser();
            var transactionReferenceNumber = tag20Parser.Parse(":20:942S161226095110");
    
            Assert.Equal("942", transactionReferenceNumber.Format);
            Assert.Equal("S", transactionReferenceNumber.FormatCode);
            Assert.Equal(new DateTime(2016, 12, 26, 09, 51, 10), transactionReferenceNumber.TransactionDateTime);
        }
    }        
}