using CashWise.Api.Controllers;
using CashWise.Application.Repositories;
using CashWise.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CashWise.Api.UnitTests.Controllers;

[TestFixture]
public class TransactionControllerTests
{
    private MockRepository mockRepository;
    private Mock<ITransactionRepository> mockTransactionRepository;
    private TransactionsController controller;

    private const int Id = 1;

    [SetUp]
    public void Setup()
    {
        mockRepository = new MockRepository(MockBehavior.Strict);
        mockTransactionRepository = mockRepository.Create<ITransactionRepository>();
        controller = new TransactionsController(mockTransactionRepository.Object);
    }
    
    [TearDown]
    public void TearDown() =>
        mockRepository.VerifyAll();

    [Test]
    public async Task GetAllTransactions_ShouldReturnAllTransactions()
    {
        // Arrange
        var hrNow = DateTime.Now;
        var transaction = new Transaction(
            amount: 100,
            description: "Test transaction",
            date: hrNow.ToString("yyyy-MM-dd HH:mm:ss"),
            transactionCategory: "Test",
            transactionType: "Test"
        );
        var transactionsResult = new List<Transaction>() { transaction };
        
        mockTransactionRepository
            .Setup(x => x.GetAllTransactionsAsync())
            .ReturnsAsync(transactionsResult);
        
        // Act
        var result = await controller.GetAllTransactionAsync();
        
        // Assert
        var response = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        response.Value.Should().BeEquivalentTo(transactionsResult);
    }

    [Test]
    public async Task CreateTransaction_WhenValidParameters_ShouldCreateTransaction()
    {
        // Arrange
        var hrNow = DateTime.Now;
        var transaction = new Transaction(
            amount: 100,
            description: "Test transaction",
            date: hrNow.ToString("yyyy-MM-dd HH:mm:ss"),
            transactionCategory: "Test",
            transactionType: "Test"
        );
        
        mockTransactionRepository
            .Setup(m => m.CreateTransactionAsync(transaction))
            .Returns(Task.CompletedTask);
        
        // Act
        var t = await controller.CreateTransactionAsync(transaction);
        
        // Assert
        var response = t.Should().BeOfType<CreatedAtActionResult>().Subject;
        response.Value.Should().BeEquivalentTo(transaction);
    }
    
    [Test]
    public async Task GetTransactionByIdAsync_WhenTransactionExists_ShouldReturnTransaction()
    {
        var hrNow = DateTime.Now;
        var transaction = new Transaction(
            amount: 100,
            description: "Test transaction",
            date: hrNow.ToString("yyyy-MM-dd HH:mm:ss"),
            transactionCategory: "Test",
            transactionType: "Test"
        );
        
        mockTransactionRepository
            .Setup(m => m.GetTransactionByIdAsync(Id))
            .ReturnsAsync(transaction);
        
        // Act
        var t = await controller.GetTransactionByIdAsync(Id);
        
        // Assert
        var response = t.Result.Should().BeOfType<OkObjectResult>().Subject;
        response.Value.Should().BeEquivalentTo(transaction);
    }
}