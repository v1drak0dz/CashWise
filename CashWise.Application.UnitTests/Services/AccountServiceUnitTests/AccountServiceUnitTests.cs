using CashWise.Application.Services.AccountService;
using CashWise.Domain.Entities;
using CashWise.Infrastructure.Repositories;
using Moq;
using FluentAssertions;
using Newtonsoft.Json.Serialization;

namespace CashWise.Application.UnitTests.Services.AccountServiceUnitTests
{
    public class AccountServiceUnitTests
    {
        private Mock<AccountRepository> _accountRepositoryMock;
        
        private MockRepository _mockRepository;
        private AccountService _accountService;
        private StringWriter StringWriter = new();

        private const int ErrorId = -1;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _accountRepositoryMock = new Mock<AccountRepository>(MockBehavior.Strict);

            _accountService = new AccountService(_accountRepositoryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void CreateAsync_WhenNameIsNotEmpty_ReturnId()
        {
            // Arrange
            var accountName = "Banco do Brasil";

            // Act
            var result = _accountService.CreateAsync(accountName);

            // Assert
            result.Should().Be(1);
            result.Should().BeOfType<int>();
            _accountRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Account>()), Times.Once);
        }
    }
}
