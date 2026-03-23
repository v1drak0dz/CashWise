using CashWise.Application.UseCases.RecurringExpenses;
using CashWise.Domain.Entities;
using CashWise.Domain.Enums;
using FluentAssertions;

namespace CashWise.Application.UnitTests.UseCases.RecurringExpenses
{
    [TestFixture]
    public class RecurringExpenseDetectorTests
    {
        private IRecurringExpenseDetector _detector;

        private const string Netflix = "Netflix";
        private const string Spotify = "Spotify";
        private const string Market = "Market";

        [SetUp]
        public void Setup()
        {
            _detector = new RecurringExpenseDetector();
        }

        [Test]
        public void Detect_WhenMonthlyExpense_ShouldReturnRecurringExpense()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense(Netflix, 30m, new DateTime(2024, 1, 1)),
                Expense(Netflix, 30m, new DateTime(2024, 2, 1)),
                Expense(Netflix, 30m, new DateTime(2024, 3, 1)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().ContainSingle();

            var recurring = result.First();
            recurring.Description.Should().Contain("netflix");
            recurring.Frequency.Should().Be(FrequencyType.Monthly);
            recurring.Confidence.Should().BeGreaterThan(0.7);
        }

        [Test]
        public void Detect_WhenRandomExpenses_ShouldReturnEmpty()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense(Market, 100m, DateTime.Today),
                Expense(Market, 200m, DateTime.Today.AddDays(3)),
                Expense(Market, 50m, DateTime.Today.AddDays(10)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Detect_WhenDatesSlightlyDifferent_ShouldStillDetectRecurring()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense(Spotify, 20m, new DateTime(2024, 1, 1)),
                Expense(Spotify, 20m, new DateTime(2024, 1, 30)),
                Expense(Spotify, 20m, new DateTime(2024, 3, 2)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().ContainSingle();
        }

        [Test]
        public void Detect_WhenConsistent_ShouldReturnHighConfidence()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense("Gym", 100m, new DateTime(2024, 1, 1)),
                Expense("Gym", 100m, new DateTime(2024, 2, 1)),
                Expense("Gym", 100m, new DateTime(2024, 3, 1)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().ContainSingle();
            result.First().Confidence.Should().BeGreaterThan(0.7);
        }

        [Test]
        public void Detect_WhenLessThanThreeOccurrences_ShouldIgnore()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense(Netflix, 30m, new DateTime(2024, 1, 1)),
                Expense(Netflix, 30m, new DateTime(2024, 2, 1)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Detect_WhenWeeklyExpense_ShouldDetectWeeklyFrequency()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense("Gym", 50m, new DateTime(2024, 1, 1)),
                Expense("Gym", 50m, new DateTime(2024, 1, 8)),
                Expense("Gym", 50m, new DateTime(2024, 1, 15)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().ContainSingle();
            result.First().Frequency.Should().Be(FrequencyType.Weekly);
        }

        [Test]
        public void Detect_WhenDescriptionsDifferSlightly_ShouldStillGroup()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                Expense("Netflix", 30m, new DateTime(2024, 1, 1)),
                Expense("NETFLIX.COM", 30m, new DateTime(2024, 2, 1)),
                Expense("Netflix 123", 30m, new DateTime(2024, 3, 1)),
            };

            // Act
            var result = _detector.Detect(transactions);

            // Assert
            result.Should().ContainSingle();
        }

        // Helper

        private static Transaction Expense(string description, decimal amount, DateTime date)
        {
            return new Transaction(
                date,
                description,
                amount,
                TransactionCategory.Home,
                TransactionType.Expense,
                true
            );
        }
    }
}