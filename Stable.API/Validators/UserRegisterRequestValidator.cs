using FluentValidation;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Requests;

namespace Stable.API.Validators
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            this.RuleFor(u => u.FirstName).NotEmpty().MinimumLength(3);
            this.RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
            this.RuleFor(u => u.Email).NotEmpty().EmailAddress().Must(ValidationHelper.CheckEmailValidation);
            this.RuleFor(u => u.PhoneNumber).NotEmpty().Must(ValidationHelper.CheckPhoneNumberValidation);
            this.RuleFor(u => u.Address).NotEmpty().Length(20, 250);
            this.RuleFor(u => u.Postcode).NotEmpty();
            this.RuleFor(u => u.BirthDate).NotEmpty().LessThanOrEqualTo(System.DateTime.Now.AddYears(-18));
            this.RuleFor(u => u.IdentityNumber).NotEmpty();
            this.RuleFor(u => u.Password).NotEmpty().Length(9, 15).Must(ValidationHelper.CheckPasswordValidation);
            this.RuleFor(u => u.CurrencyTypeId).NotEmpty().InclusiveBetween(1, 6);
            this.RuleFor(u => u.AccountTypeId).NotEmpty().InclusiveBetween(1, 4);
        }
    }
}
