using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public static class Tag13dParser
    {
        public static DateTimeIndication Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:13D:)
                (?<number>\d{5})",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);

            var date = int.Parse(match.Groups["number"].Value);

            return new DateTimeIndication(date);
        }
    }
}