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
        private readonly Mock<AccountRepository> _accountRepositoryMock = new();
        private readonly Mock<Account> _accountMock = new();
        private AccountService _accountService;
        private StringWriter StringWriter = new();

        private const int ErrorId = -1;

        [SetUp]
        public void Setup()
        {
            _accountRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Account>()))
                .Returns(Task.FromResult(_accountRepositoryMock.Object));

            _accountRepositoryMock
                .Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(1))))
                .ReturnsAsync(new Account(It.IsAny<string>()));

            _accountService = new AccountService(_accountRepositoryMock.Object);
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

        [Test]
        public void CreateAsync_WhenNameIsEmpty_ThrowException()
        {
            // Arrange
            var accountName = string.Empty;
            Console.SetOut(StringWriter);

            // Act
            var result = _accountService.CreateAsync(accountName);

            // Assert
            result.Should().Be(ErrorId);
            StringWriter.ToString().Should().Contain("Invalid name to account");
        }
    }
}
