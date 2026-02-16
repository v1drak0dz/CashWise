using CashWise.Domain.Entities;
using FluentValidation;

namespace CashWise.Application.Validators.TransactionValidators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(t => t.Description)
                .MinimumLength(5).WithMessage("Minimum of 5 characters for a description!");

            RuleFor(t => t.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Amound should not be negative");

        }
    }
}
