using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag34fParserTests
    {
        [Fact]
        public void BasicParser() 
        {
            var parser = new Tag34FParser();
            var floorLimitIndicator = parser.Parse(":34F:EUR0");

            Assert.Equal("EUR", floorLimitIndicator.Currency);
            Assert.Equal(0, floorLimitIndicator.Amount);
        }
    }    
}