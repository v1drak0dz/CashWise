using CashWise.Application.UseCases.InvestmentUseCase.SellInvestment;
using CashWise.Domain.Entities;
using CashWise.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace CashWise.Application.UnitTests.UseCases.InvestmentUseCase
{
    [TestFixture]
    public class SellInvestmentTests
    {
        private MockRepository _mockRepository;
        private Mock<IInvestmentPositionRepository> _mockInvestmentPositionRepository;
        private ISellInvestment _sellInvestment;
        private InvestmentPosition _investmentPosition;

        private const string Asset = "PETR4.SA";
        private const decimal Value = 2m;
        private const int Quantity = 3;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockInvestmentPositionRepository = _mockRepository.Create<IInvestmentPositionRepository>(MockBehavior.Strict);
            _sellInvestment = new SellInvestment(_mockInvestmentPositionRepository.Object);
            _investmentPosition = new InvestmentPosition(Asset, Quantity, Value);
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task Sell_WhenPositionNull_ThrowException()
        {
            _mockInvestmentPositionRepository
                .Setup(x => x.GetInvestmentPositionAsync(Asset))
                .Returns(Task.FromResult<InvestmentPosition?>(null));

            Func<Task> result = async () => await _sellInvestment.Sell(Asset, Quantity, Value);

            await result.Should().ThrowAsync<ArgumentNullException>();
            _mockInvestmentPositionRepository.Verify(x => x.UpdateInvestmentPositionAsync(_investmentPosition), Times.Never);
        }

        [Test]
        public async Task Sell_WhenPositionNotNull_CallUpdate()
        {
            _mockInvestmentPositionRepository
                .Setup(x => x.GetInvestmentPositionAsync(Asset))
                .Returns(Task.FromResult<InvestmentPosition?>(_investmentPosition));

            _mockInvestmentPositionRepository
                .Setup(x => x.UpdateInvestmentPositionAsync(_investmentPosition))
                .Returns(Task.CompletedTask);

            await _sellInvestment.Sell(Asset, Quantity, Value);

            _mockInvestmentPositionRepository.Verify(x => x.UpdateInvestmentPositionAsync(_investmentPosition), Times.Once);
        }
    }
}
