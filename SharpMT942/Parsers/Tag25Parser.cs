using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public class Tag25Parser
    {

        public AccountIdentifier Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:\d\d:)
                (?<accountIdentifier>.{1,35})",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            Match match = regex.Match(data);
            return new AccountIdentifier(match.Groups["accountIdentifier"].Value);
        }
    }
}