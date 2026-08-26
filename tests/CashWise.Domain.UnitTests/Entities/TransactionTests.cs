using CashWise.Domain.Entities;
using FluentAssertions;

namespace CashWise.Domain.UnitTests;

[TestFixture]
public class TransactionTests
{
    private const string Description = "Test";
    private const decimal Amount = 1.00m;
    private const string Date = "2026-08-26";
    private const string TransactionCategory = "Test";
    private const string TransactionType = "Test";
    
    
    [Test]
    public void Constructor_WhenValidProperties_ShouldCreateTransaction()
    {
        // Arrange
        var transaction = new Transaction(Description, Amount, Date, TransactionCategory, TransactionType);
        
        //Act
        
        // Assert
        transaction.Description.Should().Be(Description);
        transaction.Amount.Should().Be(Amount);
        transaction.Date.Should().Be(Date);
        transaction.TransactionCategory.Should().Be(TransactionCategory);
        transaction.TransactionType.Should().Be(TransactionType);
    }

    [TestCase("some test", "-1.0", TestName = "Constructor_WhenNegativeAmount_ShouldThrowError")]
    [TestCase("so", "1", TestName = "Constructor_WhenInvalidDescription_ShouldThrowError")]
    public void Constructor_WhenInvalid_ShouldThrowError(string desc, string amount)
    {
        // Arrange
        decimal.TryParse(amount, out var amountAsDecimal);
        Func<Transaction> transaction = () => new Transaction(desc, amountAsDecimal, Date, TransactionCategory, TransactionType);
        
        //Act
        
        // Assert
        transaction.Should().Throw<ArgumentOutOfRangeException>();
    }
}