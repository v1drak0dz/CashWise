using CashWise.Application.DTOs;
using FluentValidation;

namespace CashWise.Api.WebApi.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionRequestDTO>
    {
        public TransactionValidator()
        {
            RuleFor(t => t.description)
                .NotEmpty()
                .WithMessage("Description field should not be empty!");
            RuleFor(t => t.amount)
                .NotEmpty()
                .WithMessage("Amount should not be empty");
        }
    }
}