using SharpMT942.Parsers;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag13DParserTests
    {
        [Fact]
        public void DateTimeIndication() 
        {
            var dateTimeIndication = Tag13dParser.Parse(":13D:15122");            
            Assert.Equal(15122, dateTimeIndication.Date);
        }
    }    
}