using AutoFixture;
using FluentAssertions;
using CarteiraApi.Models.Requests.ExchangeRate;
using CarteiraApi.Validators;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Validators
{
    public class ExchangeRateValidatorTest : BaseValidatorTest<ExchangeRateValidator>
    {
        private ExchangeRateGetRequest _request;
        public ExchangeRateValidatorTest()
        {
            _validator = new ExchangeRateValidator();
        }

        [Theory]
        [InlineData("PETR3")]
        public void Test_Exchange_Rate_Validator_Ok(string StockCode)
        {
            _request = _fixture.Create<ExchangeRateGetRequest>();
            _request.StockCode = StockCode;

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_Exchange_Rate_Validator_Error(string StockCode)
        {
            _request = _fixture.Create<ExchangeRateGetRequest>();
            _request.StockCode = StockCode;
            
            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
