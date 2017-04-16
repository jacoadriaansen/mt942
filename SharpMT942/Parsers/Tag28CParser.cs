using System.Text.RegularExpressions;

namespace SharpMT942.Parsers
{
    public static class Tag28CParser
    {
        public static TransactionStatementNumber Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:28c:)
                (?<statementnumber>\d{5})
                (/(?<sequencenumber>\d{5}))?",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);

            var statementNumber = int.Parse(match.Groups["statementnumber"].Value);

            var sequenceNumberGroup = match.Groups["sequencenumber"];
            var sequenceNumber = sequenceNumberGroup.Success
                ? int.Parse(sequenceNumberGroup.Value)
                : default(int?);

            return new TransactionStatementNumber(statementNumber, sequenceNumber);
        }
    }
}