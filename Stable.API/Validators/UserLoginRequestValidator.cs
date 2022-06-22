using FluentValidation;
using Stable.Business.Concrete.Requests;

namespace Stable.API.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            this.RuleFor(u => u.Email).NotEmpty();
            this.RuleFor(u => u.Password).NotEmpty().MinimumLength(9).MaximumLength(15);
        }
    }
}
