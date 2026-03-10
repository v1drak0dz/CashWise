using Moq;
using FluentAssertions;

using CashWise.Domain.Repositories;
using CashWise.Domain.Entities;
using CashWise.Domain.Enums;
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
        private CreateTransaction _createTransaction;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _transactionRepository = _mockRepository.Create<ITransactionRepository>(MockBehavior.Strict);
            _transactionValidator = _mockRepository.Create<IValidator<Transaction>>(MockBehavior.Strict);
            _createTransaction = new CreateTransaction(_transactionRepository.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task CreateTransactionAsync_ThrowError()
        {
            // Arrange
            //var transaction = new Transaction(DateTime.Today, string.Empty, -10m, TransactionCategory.Home, TransactionType.Expense, true);

            //// Act
            //Func<Task> result = async () => await _createTransaction.CreateTransactionAsync(transaction);

            //// Assert
            //await result.Should().ThrowAsync<MockException>();
        }

        [Test]
        public async Task CreateTransactionAsync_WhenAmountNotNegative_ReturnsId()
        {
            // Arrange
            //var transaction = new Transaction(DateTime.Today, string.Empty, 10m, TransactionCategory.Home, TransactionType.Expense, true);

            //_transactionValidator
            //    .Setup(x => x.ValidateAsync(transaction, default))
            //    .ReturnsAsync(new ValidationResult());

            //_transactionRepository
            //    .Setup(x => x.AddAsync(transaction))
            //    .Returns(Task.CompletedTask);

            //// Act
            //var result = await _createTransaction.CreateTransactionAsync(transaction);

            //// Assert
            //result.Should().Be(transaction);
            //_transactionRepository.Verify(r => r.AddAsync(transaction),Times.Once);
        }
    }
}
