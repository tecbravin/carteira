using FluentValidation;
using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Resources;

namespace CarteiraApi.Validators
{
    public class OperationAddValidator : AbstractValidator<OperationAddRequest>
    {
        public OperationAddValidator()
        {
            RuleFor(e => e.StockCode).NotNull().WithMessage(string.Format(Resource.Required, Resource.StockCode));
            RuleFor(e => e.StockCode).NotEmpty().WithMessage(string.Format(Resource.Required, Resource.StockCode));
            RuleFor(e => e.StockCode).MaximumLength(15).WithMessage(string.Format(Resource.MaxSize, Resource.StockCode, 15));

            RuleFor(e => e.Operation).NotNull().WithMessage(string.Format(Resource.Required, Resource.Operation));
            RuleFor(e => e.Operation).NotEmpty().WithMessage(string.Format(Resource.Required, Resource.Operation));

            RuleFor(e => e.Price).NotNull().WithMessage(string.Format(Resource.Required, Resource.Price));
            RuleFor(e => e.Price).GreaterThan(0).WithMessage(string.Format(Resource.GreaterThanZero, Resource.Price));

            RuleFor(e => e.Quantity).NotNull().WithMessage(string.Format(Resource.Required, Resource.Quantity));
            RuleFor(e => e.Quantity).GreaterThan(0).WithMessage(string.Format(Resource.GreaterThanZero, Resource.Quantity));
        }
    }
}
