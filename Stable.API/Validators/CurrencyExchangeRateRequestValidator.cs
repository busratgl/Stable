using FluentValidation;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;

namespace Stable.API.Validators
{
    public class CurrencyExchangeRateRequestValidator : AbstractValidator<CurrencyExchangeRateRequest>
    {
        public CurrencyExchangeRateRequestValidator()
        {
            this.RuleFor(ce => ce.Day).NotEmpty();
            this.RuleFor(ce => ce.Month).NotEmpty();
            this.RuleFor(ce => ce.Year).NotEmpty();
        }
    }
}
