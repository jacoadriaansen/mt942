using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag13dParserTests
    {
        [Fact]
        public void BasicParser() 
        {
            var parser = new Tag13DParser();
            var dateTimeIndication = parser.Parse(":13D:15122");
            
            Assert.Equal(15122, dateTimeIndication.Date);
        }
    }    
}