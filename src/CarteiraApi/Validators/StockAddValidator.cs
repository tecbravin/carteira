using FluentValidation;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Resources;

namespace CarteiraApi.Validators
{
    public class StockAddValidator : AbstractValidator<StockAddRequest>
    {
        public StockAddValidator()
        {
            RuleFor(e => e.CompanyName).NotNull().WithMessage(string.Format(Resource.Required, Resource.CompanyName));
            RuleFor(e => e.CompanyName).NotEmpty().WithMessage(string.Format(Resource.Required, Resource.CompanyName));
            RuleFor(e => e.CompanyName).MaximumLength(255).WithMessage(string.Format(Resource.MaxSize, Resource.CompanyName, 255));

            RuleFor(e => e.StockCode).NotNull().WithMessage(string.Format(Resource.Required, Resource.StockCode));
            RuleFor(e => e.StockCode).NotEmpty().WithMessage(string.Format(Resource.Required, Resource.StockCode));
            RuleFor(e => e.StockCode).MaximumLength(15).WithMessage(string.Format(Resource.MaxSize, Resource.StockCode, 15));
        }
    }
}