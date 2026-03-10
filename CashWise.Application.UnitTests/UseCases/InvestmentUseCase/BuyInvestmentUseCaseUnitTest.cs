using CashWise.Application.Factories.InvestmentPositionFactory;
using CashWise.Application.UseCases.InvestmentUseCase.SellInvestmentUseCase;
using CashWise.Domain.Entities;
using CashWise.Domain.Repositories;
using Moq;
using FluentAssertions;

namespace CashWise.Application.UnitTests.UseCases.InvestmentUseCase
{
    public class BuyInvestmentUseCaseUnitTest
    {
        private MockRepository _mockRepository;
        private Mock<IInvestmentRepository> _mockInvestmentRepository;
        private Mock<IInvestmentPositionFactory> _mockInvestmentPositionFactory;
        private ISellInvestmentUseCase _sellInvestmentUseCase;

        private const string Asset = "PETR4.SA";

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockInvestmentRepository = _mockRepository.Create<IInvestmentRepository>(MockBehavior.Strict);
            _mockInvestmentPositionFactory = _mockRepository.Create<IInvestmentPositionFactory>(MockBehavior.Strict);
            _sellInvestmentUseCase = new SellInvestmentUseCase(_mockInvestmentRepository.Object, _mockInvestmentPositionFactory.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task Execute_WhenValidPosition_ShouldUpdate()
        {
            // Arrange
            var position = new InvestmentPosition(Asset, 2, 10m);

            //_mockInvestmentPositionFactory
            //    .Setup(x => x.Create(Asset))
            //    .Returns(position);

            //_mockInvestmentRepository
            //    .Setup(x => x.GetInvestmentPositionAsync(It.IsAny<int>()))
            //    .ReturnsAsync(null);

            //_mockInvestmentRepository
            //    .Setup(x => x.UpdateInvestmentPositionAsync(position))
            //    .Returns(Task.CompletedTask);

            //// Act
            //await _sellInvestmentUseCase.Execute(position.Id, Asset, 2, 10m);

            // Assert

        }
    }
}
