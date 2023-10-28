using FluentValidation;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;

namespace Tumsas.RealEstate.CrossCuttingConcern.FluentValidations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage(p => "User name is required")
                .Length(1, 64).WithMessage(p => "User name Should be min 1, max 64");

            RuleFor(p => p.LastName).NotEmpty().NotEmpty().WithMessage(p => "User last name  is required")
                .Length(1, 64).WithMessage(p => "User last name Should be min 1, max 64");

            RuleFor(p => p.PhoneNumber).NotEmpty().NotEmpty().WithMessage(p => "User password  is required")
              .Length(1, 32).WithMessage(p => "User password Should be min 1, max 32");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Invalid email address")
                .Length(1, 64)
                .WithMessage(p => "Mail address should be min 1, max 64");      

            RuleFor(p => p.Password).NotEmpty()
                .WithMessage(p => "Password is required")
                .Length(8, 64)
                .WithMessage(p => "Password should be min 8, max 64");
        }
    }
}