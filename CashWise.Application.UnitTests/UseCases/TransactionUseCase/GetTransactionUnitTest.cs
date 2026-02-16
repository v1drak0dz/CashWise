using CashWise.Domain.Repositories;
using Moq;

namespace CashWise.Application.UnitTests.UseCases.TransactionUseCase
{
    public class GetTransactionUnitTest
    {
        private MockRepository _mockRepository;
        private Mock<ITransactionRepository> _transactionRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _transactionRepository = new Mock<ITransactionRepository>(MockBehavior.Strict);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }
    }
}
