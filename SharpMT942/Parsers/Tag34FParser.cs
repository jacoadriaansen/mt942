using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public class Tag34FParser
    {
        public FloorLimitIndicator Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:34F:)
                (?<currency>[A-Z]{3})
                (?<amount>\d{1})",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);

            var amount = decimal.Parse(match.Groups["amount"].Value);
            var currency = match.Groups["currency"].Value;

            return new FloorLimitIndicator(amount, currency);
        }
    }
}