using FluentValidation;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;

namespace Stable.API.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            this.RuleFor(u => u.Email).NotEmpty().EmailAddress().Must(ValidationHelper.CheckEmailValidation);
            this.RuleFor(u => u.Password).NotEmpty().Length(9, 15).Must(ValidationHelper.CheckPasswordValidation);
        }
    }
}
