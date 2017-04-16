using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public static class Tag34FParser
    {
        public static Money Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:34F:)
                (?<currency>[A-Z]{3})
                (?<amount>\d{1,15})
                (((,|.)(?<decimals>\d{0,2}))?)",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);

            var amount = decimal.Parse($"{match.Groups["amount"].Value}.{match.Groups["decimals"].Value}", NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            var currency = match.Groups["currency"].Value;

            return new Money(amount, currency);
        }
    }
}