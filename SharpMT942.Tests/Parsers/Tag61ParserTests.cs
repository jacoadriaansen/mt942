using System;
using SharpMT942.Parsers;
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

        [Fact]
        public void TransactionType()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(TransactionTypes.Msc, statement.TransactionType);
        }

        [Fact]
        public void CustomerReference()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");
            
            Assert.Equal("ABCDEFGHIJKLMNOP", statement.CustomerReference);
        }

        [Fact]
        public void BankReference()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal("ABCDEFGHIJKLMNOP", statement.BankReference);
        }

        [Fact]
        public void SupplementaryDetails()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVXYZ1234567", statement.SupplementaryDetails);
        }
    }
}