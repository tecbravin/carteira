using FluentAssertions;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Validators;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Validators
{
    public class StockAddValidatorTest : BaseValidatorTest<StockAddValidator>
    {
        private StockAddRequest _request;
        public StockAddValidatorTest()
        {
            _validator = new StockAddValidator();
        }

        [Theory]
        [InlineData("PETR3", "Petrobrás")]
        public void Test_Stock_Validator_Ok(string StockCode, string companyName)
        {
            _request = new StockAddRequest
            {
                StockCode = StockCode,
                CompanyName = companyName
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("", "Petrobrás")]
        [InlineData(null, "Petrobrás")]
        [InlineData("PETR3", "")]
        [InlineData("PETR3", null)]
        public void Test_Stock_Validator_Error(string StockCode, string companyName)
        {
            _request = new StockAddRequest
            {
                StockCode = StockCode,
                CompanyName = companyName
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
