using FluentValidation;
using Stable.Business.Requests;

namespace Stable.API.Validators
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            this.RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);
            this.RuleFor(x => x.LastName).NotEmpty().MinimumLength(2);
            this.RuleFor(x => x.Email).NotEmpty();
            this.RuleFor(x => x.PhoneNumber).NotEmpty();
            this.RuleFor(x => x.Address).NotEmpty();
            this.RuleFor(x => x.BirthDate).NotEmpty().LessThanOrEqualTo(System.DateTime.Now.AddYears(-18));
            this.RuleFor(x => x.IdentityNumber).NotEmpty();
            this.RuleFor(x => x.Password).NotEmpty().MinimumLength(9).MaximumLength(15);
        }
    }
}
