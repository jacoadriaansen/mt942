using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace SharpMT942.Tests.Parsers
{
    public class Tag61ParserTests
    {
        [Fact]
        public void ValueDate()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(new DateTime(2016, 12, 28), statement.ValueDate);
        }

        [Fact]
        public void EntryDate()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(new DateTime(2016, 12, 29), statement.EntryDate);
        }

        [Fact]
        public void DebitOrCredit()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(TransactionDirection.Debit, statement.DebitOrCredit);
        }

        [Fact]
        public void Amount()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(1000.00, statement.Amount);
            Assert.Equal(TransactionTypes.Msc, statement.TransactionType);
            Assert.Equal("ABCDEFGHIJKLMNOP", statement.CustomerReference);
            Assert.Equal("ABCDEFGHIJKLMNOP", statement.BankReference);
            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVXYZ1234567", statement.SupplementaryDetails);
        }
    }

    public class Tag61Parser 
    {
        readonly Dictionary<string, TransactionType> _transactionTypes;

        public Tag61Parser()
        {
            _transactionTypes = new Dictionary<string, TransactionType>
            {
                {"MSC", TransactionTypes.Msc}
            };
        }
        
        public Statement Parse(string data)
        {
            var regex = new Regex
            (
                @"(?<tag>:61:)
                (?<year>\d\d\d\d)
                (?<valuemonth>\d\d)
                (?<valueday>\d\d)
                (?<entrymonth>\d\d)
                (?<entryday>\d\d)
                (?<debitOrCredit>D|C|RD|RC)
                (?<fundsCode>\w?)
                (?<amount>\d+)([.,](?<decimal>\d\d))
                [FN]
                (?<transactionType>\w{3})
                (?<customerReference>\w{1,16})
                /{2}?
                (?<bankReference>\w{1,16})?
                (?<supplementaryDetails>\w{1,32})?", 
                RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase
            );

            var match = regex.Match(data);

            var year = int.Parse(match.Groups["year"].Value);
            var valuemonth = int.Parse(match.Groups["valuemonth"].Value);
            var valueday = int.Parse(match.Groups["valueday"].Value);
            var entrymonth = int.Parse(match.Groups["entrymonth"].Value);
            var entryday = int.Parse(match.Groups["entryday"].Value);
            
            var debitOrCredit = match.Groups["debitOrCredit"].Value;
            
            var amount = Convert.ToDouble(match.Groups["amount"].Value);
            
            var transactionDirection = FindTransactionDirection(debitOrCredit);

            var transactionType = _transactionTypes[match.Groups["transactionType"].Value];

            var customerReference = match.Groups["customerReference"].Value;
            var bankReference = match.Groups["bankReference"].Value;
            var supplementaryDetails = match.Groups["supplementaryDetails"].Value;


            return new Statement
            (
                new DateTime(year, valuemonth,valueday),
                new DateTime(year, entrymonth, entryday),
                transactionDirection,
                amount,
                transactionType,
                customerReference,
                bankReference,
                supplementaryDetails
            );
        }

        public TransactionDirection FindTransactionDirection(string value)
        {
            switch(value)
            {
                case "D":
                {
                    return TransactionDirection.Debit;
                }
                case "C":
                {
                    return TransactionDirection.Credit;
                }
                case "RD":
                {
                    return TransactionDirection.ReverseDebit;
                }
                case "RC":
                {
                    return TransactionDirection.ReverseCredit;
                }

                default:
                {
                    return TransactionDirection.Unknown;
                }
            }
        }
    }
}