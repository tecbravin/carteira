using FluentAssertions;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Validators;
using Xunit;

namespace CarteiraApiTest.Validators
{
    public class StockUpdateValidatorTest : BaseValidatorTest<StockUpdateValidator>
    {
        private StockUpdateRequest _request;
        public StockUpdateValidatorTest()
        {
            _validator = new StockUpdateValidator();
        }

        [Theory]
        [InlineData(1, "PETR3", "Petrobrás")]
        public void Test_Stock_Validator_Ok(int id, string StockCode, string companyName)
        {
            _request = new StockUpdateRequest
            {
                Id = id,
                StockCode = StockCode,
                CompanyName = companyName
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0, "PETR3", "Petrobrás")]
        public void Test_Stock_Validator_Id_Error(int id, string StockCode, string companyName)
        {
            _request = new StockUpdateRequest
            {
                Id = id,
                StockCode = StockCode,
                CompanyName = companyName
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("", "Petrobrás")]
        [InlineData(null, "Petrobrás")]
        [InlineData("PETR3", "")]
        [InlineData("PETR3", null)]
        public void Test_Stock_Validator_Error(string StockCode, string companyName)
        {
            _request = new StockUpdateRequest
            {
                StockCode = StockCode,
                CompanyName = companyName
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
