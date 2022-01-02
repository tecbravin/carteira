using FluentAssertions;
using CarteiraApi.Models.Enums;
using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Validators;
using Xunit;

namespace CarteiraApiTest.Validators
{
    public class OperationAddValidatorTest : BaseValidatorTest<OperationAddValidator>
    {
        private OperationAddRequest _request;
        public OperationAddValidatorTest()
        {
            _validator = new OperationAddValidator();
        }

        [Theory]
        [InlineData("PETR3", EOperationType.Buy, 11.32, 4)]
        public void Test_Stock_Event_Validator_Ok(string StockCode, EOperationType operation, decimal price, int quantity)
        {
            _request = new OperationAddRequest
            {
                StockCode = StockCode,
                Operation = operation,
                Price = price,
                Quantity = quantity
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("PETR3", EOperationType.Buy, 15, 0)]
        [InlineData("PETR3", EOperationType.Buy, 0, 4)]
        [InlineData("PETR3", null, 11.32, 4)]
        [InlineData("", EOperationType.Buy, 11.32, 4)]
        [InlineData(null, EOperationType.Buy, 11.32, 4)]
        public void Test_Stock_Event_Validator_Error(string StockCode, EOperationType? operation, decimal price, int quantity)
        {
            _request = new OperationAddRequest
            {
                StockCode = StockCode,
                Operation = operation,
                Price = price,
                Quantity = quantity
            };

            var validationResult = _validator.Validate(_request);
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
