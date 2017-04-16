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
        public void Amount_WithDot()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(1000.00M, statement.Amount);
        }

        [Fact]
        public void Amount_WithDotDecimals()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000.50NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(1000.50M, statement.Amount);
        }

        [Fact]
        public void Amount_WithComma()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000,00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(1000.00M, statement.Amount);
        }

        [Fact]
        public void Amount_WithCommaDecimals()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse(":61:201612281229DA1000,50NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal(1000.50M, statement.Amount);
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
        public void SupplementaryDetailsUnixes()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse($":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOP\nABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVXYZ1234567", statement.SupplementaryDetails);
        }

        [Fact]
        public void SupplementaryDetailsWindows()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse($":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOP\r\nABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVXYZ1234567", statement.SupplementaryDetails);
        }


        [Fact]
        public void SupplementaryDetailsWithOutNewLine()
        {
            var parser = new Tag61Parser();
            var statement = parser.Parse($":61:201612281229DA1000.00NMSCABCDEFGHIJKLMNOP//ABCDEFGHIJKLMNOPABCDEFGHIJKLMNOPQRSTUVXYZ1234567");

            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVXYZ1234567", statement.SupplementaryDetails);
        }
    }
}