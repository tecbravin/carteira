using FluentValidation;
using CarteiraApi.Models.Requests.ExchangeRate;
using CarteiraApi.Resources;

namespace CarteiraApi.Validators
{
    public class ExchangeRateValidator : AbstractValidator<ExchangeRateGetRequest>
    {
        public ExchangeRateValidator()
        {
            RuleFor(e => e.StockCode).NotNull().WithMessage(string.Format(Resource.Required, Resource.StockCode));
            RuleFor(e => e.StockCode).NotEmpty().WithMessage(string.Format(Resource.Required, Resource.StockCode));
        }
    }
}
