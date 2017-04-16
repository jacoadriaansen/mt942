using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag25ParserTests
    {
        [Fact]
        public void AccountNumber() 
        {   
            var accountNumber = Tag25Parser.Parse(":25:123456789ABCD");

            Assert.Equal("123456789ABCD", accountNumber.Value);
        }
    }   
}