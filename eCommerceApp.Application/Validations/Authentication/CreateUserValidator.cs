using eCommerceApp.Application.DTOs.Identity;
using FluentValidation;

namespace eCommerceApp.Application.Validations.Authentication
{
    public class CreateUserValidator : BaseModelValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Fullname)
                .NotEmpty().WithMessage("Full name is required.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match.");
        }
    }
}
