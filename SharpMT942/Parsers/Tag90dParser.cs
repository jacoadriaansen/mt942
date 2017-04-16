using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public static class Tag90dParser
    {
        public static NumberOfEntitiesTransactionReport Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:90D:)
                (?<numberOfEntities>\d{1,5})                
                (?<currency>[A-Za-z]{3})                
                (?<amount>\d{1,15})",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);
            
            var numberOfEntities = int.Parse(match.Groups["numberOfEntities"].Value);
            var amount = long.Parse(match.Groups["amount"].Value);
            var currency = match.Groups["currency"].Value;

            
            return new NumberOfEntitiesTransactionReport
            (
                numberOfEntities,
                new Money(amount, currency)
            );
        } 
    }
}
