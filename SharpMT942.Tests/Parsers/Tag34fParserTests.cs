using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag34FParserTests
    {
        [Fact]
        public void FloorLimitIndicator() 
        {
            var floorLimitIndicator = Tag34FParser.Parse(":34F:EUR0");

            var expectedfloorLimitIndicator = new Money(0, "EUR");
            Assert.Equal(expectedfloorLimitIndicator, floorLimitIndicator);
        }

        [Fact]
        public void CurrentAbnAmro()
        {
            var floorLimitIndicator = Tag34FParser.Parse(":34F:EUR0,00");

            var expectedfloorLimitIndicator = new Money(0, "EUR");
            Assert.Equal(expectedfloorLimitIndicator, floorLimitIndicator);
        }

        [Fact]
        public void CurrentAbnAmro_WithValue_DontCareAboutComma()
        {
            var floorLimitIndicator = Tag34FParser.Parse(":34F:EUR100,50");

            var expectedfloorLimitIndicator = new Money(100.50M, "EUR");
            Assert.Equal(expectedfloorLimitIndicator, floorLimitIndicator);
        }

        [Fact]
        public void CurrentAbnAmro_WithValue_DontCareAboutDot()
        {
            var floorLimitIndicator = Tag34FParser.Parse(":34F:EUR100.50");

            var expectedfloorLimitIndicator = new Money(100.50M, "EUR");
            Assert.Equal(expectedfloorLimitIndicator, floorLimitIndicator);
        }
        
        [Fact]
        public void NewDeutscheBank()
        {
            var floorLimitIndicator = Tag34FParser.Parse(":34F:EUR0,");

            var expectedfloorLimitIndicator = new Money(0, "EUR");
            Assert.Equal(expectedfloorLimitIndicator, floorLimitIndicator);
        }
    }
}