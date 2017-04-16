using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag90dParserTests
    {
        [Fact]
        public void TotalNumberDebitCount()
        {
            var result = Tag90DParser.Parse(":90D:12345EUR123456789012345");
            Assert.Equal(12345, result.NumberOfEntities);
        }

        [Fact]
        public void TotalNumberDebitCurrency()
        {
            var result = Tag90DParser.Parse(":90D:12345EUR123456789012345");
            Assert.Equal("EUR", result.Amount.Currency);
        }

        [Fact]
        public void TotalNumberDebitCurrencyAmount()
        {
            var result = Tag90DParser.Parse(":90D:12345EUR123456789012345");
            Assert.Equal(123456789012345, result.Amount.Amount);
        }
    }
}
