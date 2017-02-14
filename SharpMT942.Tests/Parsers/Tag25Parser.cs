using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag25ParserTests
    {
        [Fact]
        public void BasicParser() 
        {   
            var parser = new Tag25Parser();
            var accountNumber = parser.Parse(":25:123456789ABCD");

            Assert.Equal("123456789ABCD", accountNumber.Value);
        }
    }   
}