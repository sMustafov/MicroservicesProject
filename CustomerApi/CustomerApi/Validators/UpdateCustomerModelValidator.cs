namespace CustomerApi.Validators
{
    using CustomerApi.Models;
    using FluentValidation;
    using System;
    public class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .MinimumLength(2)
                .WithMessage("The first name must be at least 2 character long");

            RuleFor(x => x.LastName)
                .NotNull()
                .MinimumLength(2)
                .WithMessage("The last name must be at least 2 character long");

            RuleFor(x => x.Birthday)
                .InclusiveBetween(DateTime.Now.AddYears(-120).Date, DateTime.Now)
                .WithMessage("The birthday must not be longer ago than 120 years and can not be in the future");

            RuleFor(x => x.Age)
                .InclusiveBetween(0, 120)
                .WithMessage("The minimum age is 0 and the maximum age is 120 years");
        }
    }
}
