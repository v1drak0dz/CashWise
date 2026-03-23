using CashWise.Api.DTOs;
using FluentValidation;

namespace CashWise.Api.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionRequestDTO>
    {
        public TransactionValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Description field should not be empty!");
            RuleFor(t => t.Amount)
                .NotEmpty()
                .WithMessage("Amount should not be empty");
        }
    }
}