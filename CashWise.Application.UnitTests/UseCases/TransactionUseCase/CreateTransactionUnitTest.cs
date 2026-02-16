using Moq;
using FluentAssertions;

using CashWise.Domain.Repositories;
using CashWise.Domain.Entities;
using CashWise.Domain.Enums;
using CashWise.Application.Builders;
using CashWise.Application.UseCases.TransactionUseCase.CreateTransaction;

using FluentValidation;
using FluentValidation.Results;

namespace CashWise.Application.UnitTests.UseCases.TransactionUseCase
{
    public class CreateTransactionUnitTest
    {
        private Mock<ITransactionRepository> _transactionRepository;
        private Mock<IValidator<Transaction>> _transactionValidator;
        private MockRepository _mockRepository;
        private ICreateTransaction _createTransaction;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _transactionRepository = new Mock<ITransactionRepository>(MockBehavior.Strict);
            _transactionValidator = new Mock<IValidator<Transaction>>(MockBehavior.Strict);
            _createTransaction = new CreateTransaction(_transactionRepository.Object, _transactionValidator.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task CreateTransactionAsync_WhenAmountNegative_ThrowError()
        {
            // Arrange
            var transaction = new TransactionBuilder()
                .WithDate(DateTime.Today)
                .WithAmount(-10m)
                .WithDescription("Test negative value")
                .Build();

            _transactionValidator
                .Setup(x => x.ValidateAsync(
                    It.Is<Transaction>(x =>
                    x.Amount < 0 &&
                    x.TransactionType == TransactionType.Expense &&
                    x.TransactionCategory == TransactionCategory.Others &&
                    x.Description == "Test negative value" &&
                    x.Date == DateTime.Today), default))
                .ReturnsAsync(new ValidationResult());

            // Act
            Func<Task> result = async () => await _createTransaction.CreateTransactionAsync(transaction);

            // Assert
            await result.Should().ThrowAsync<MockException>();
        }

        [Test]
        public async Task CreateTransactionAsync_WhenAmountNotNegative_ReturnsId()
        {
            // Arrange
            var transaction = new TransactionBuilder()
                .WithDate(DateTime.Today)
                .WithAmount(10m)
                .WithDescription("Test positive value")
                .Build();

            _transactionValidator
                .Setup(x => x.ValidateAsync(
                    It.Is<Transaction>(x =>
                        x.Amount == 10m &&
                        x.TransactionType == TransactionType.Expense &&
                        x.TransactionCategory == TransactionCategory.Others &&
                        x.Description == "Test positive value" &&
                        x.Date == DateTime.Today), default))
                .ReturnsAsync(new ValidationResult());

            _transactionRepository
                .Setup(x => x.AddAsync(
                    It.Is<Transaction>(t =>
                        t.Amount == 10m &&
                        t.Description == "Test positive value" &&
                        t.Date == DateTime.Today)
                    ))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _createTransaction.CreateTransactionAsync(transaction);

            // Assert
            _transactionRepository.Verify(
                r => r.AddAsync(It.Is<Transaction>(t => t.Amount == 10m && t.Description == "Test positive value" && t.Date == DateTime.Today)),
                Times.Once
            );
        }
    }
}
