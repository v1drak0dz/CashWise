using FluentValidation;

using CashWise.Domain.Entities;

namespace CashWise.Application.Validators.TransactionValidators
{
    public class CreateTransactionValidator : AbstractValidator<Transaction>
    {
        public CreateTransactionValidator()
        {
            RuleFor(t => t.Description)
                .MinimumLength(5).WithMessage("Minimum of 5 characters for a description!");
            RuleFor(t => t.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Amount should not be negative!");
        }
    }
}
