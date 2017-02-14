using System;
using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public class Tag20Parser
    {
        public TransactionReferenceNumber Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:20:)
                (?<code>[A-Za-z\d]{3})
                (?<format>[A-Z])
                (?<year>\d{2})
                (?<month>\d{2})
                (?<day>\d{2})
                (?<hour>\d{2})
                (?<minute>\d{2})
                (?<second>\d{2})", 
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);

            // I assume this code will not survive for another 80 years.
            var year = int.Parse(20 + match.Groups["year"].Value);
            var month = int.Parse(match.Groups["month"].Value);
            var day = int.Parse(match.Groups["day"].Value);

            var hour = int.Parse(match.Groups["hour"].Value);
            var minute = int.Parse(match.Groups["minute"].Value);
            var second = int.Parse(match.Groups["second"].Value);

            return new TransactionReferenceNumber
            (
                match.Groups["code"].Value,
                match.Groups["format"].Value,
                new DateTime(year, month, day, hour, minute, second)
            );
        }
    }
}