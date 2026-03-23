using CashWise.Application.Factories.InvestmentPositionFactory;
using CashWise.Domain.Entities;
using CashWise.Domain.Repositories;
using Moq;
using CashWise.Application.UseCases.InvestmentUseCase.BuyInvestment;

namespace CashWise.Application.UnitTests.UseCases.InvestmentUseCase
{
    [TestFixture]
    public class BuyInvestmentTests
    {
        private MockRepository _mockRepository;
        private Mock<IInvestmentPositionRepository> _mockInvestmentRepository;
        private Mock<IInvestmentPositionFactory> _mockInvestmentPositionFactory;
        private IBuyInvestment _buyInvestment;

        private const string Asset = "PETR4.SA";
        private const decimal Value = 2m;
        private const int Quantity = 3;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockInvestmentRepository = _mockRepository.Create<IInvestmentPositionRepository>(MockBehavior.Strict);
            _mockInvestmentPositionFactory = _mockRepository.Create<IInvestmentPositionFactory>(MockBehavior.Strict);
            _buyInvestment = new BuyInvestment(_mockInvestmentRepository.Object, _mockInvestmentPositionFactory.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task BuyInvestment_WhenPositionNull_CreatePosition()
        {
           // Arrange
           var position = new InvestmentPosition(Asset, Quantity, Value);

            _mockInvestmentPositionFactory
                .Setup(x => x.Create(Asset))
                .Returns(position);

            _mockInvestmentRepository
                .Setup(x => x.GetInvestmentPositionAsync(Asset))
                .Returns(Task.FromResult<InvestmentPosition?>(null));

            _mockInvestmentRepository
                .Setup(x => x.AddInvestmentPositionAsync(position))
                .Returns(Task.CompletedTask);

            _mockInvestmentRepository
                .Setup(x => x.UpdateInvestmentPositionAsync(It.IsAny<InvestmentPosition>()))
                .Returns(Task.CompletedTask);

            // Act
            await _buyInvestment.Buy(Asset, Quantity, Value);

            //Assert
            _mockInvestmentRepository.Verify(x => x.AddInvestmentPositionAsync(position), Times.Once);
        }

        [Test]
        public async Task Execute_WhenPositionNotNull_UpdatePosition()
        {
            // Arrange
            var position = new InvestmentPosition(Asset, 2, 10m);

            _mockInvestmentRepository
                .Setup(x => x.GetInvestmentPositionAsync(Asset))
                .Returns(Task.FromResult<InvestmentPosition?>(position));

            _mockInvestmentRepository
                .Setup(x => x.UpdateInvestmentPositionAsync(position))
                .Returns(Task.CompletedTask);

            // Act
            await _buyInvestment.Buy(Asset, 2, 10m);

            //Assert
            _mockInvestmentRepository.Verify(x => x.UpdateInvestmentPositionAsync(position), Times.Once);
        }
    }
}
