using eCommerceApp.Application.DTOs.Identity;
using FluentValidation;

namespace eCommerceApp.Application.Validations.Authentication
{
    public class LoginUserValidator : BaseModelValidator<LoginUser>
    {
        public LoginUserValidator()
        {
            // لا داعي لكتابة أي قواعد هنا
            // لأن القواعد موجودة في BaseModelValidator
        }
    }
}
