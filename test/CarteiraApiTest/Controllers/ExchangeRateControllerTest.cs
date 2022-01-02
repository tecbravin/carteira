using AutoFixture;
using CarteiraApi.Controllers;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Requests.ExchangeRate;
using CarteiraApi.Models.Responses.ExchangeRate;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Controllers
{
    public class ExchangeRateControllerTest : BaseControllerTest
    {
        private readonly IExchangeRateService _exchangeRateService;
        private readonly ExchangeRateController _exchangeRateController;

        public ExchangeRateControllerTest()
        {
            _exchangeRateService = Substitute.For<IExchangeRateService>();
            _exchangeRateController = new ExchangeRateController(_exchangeRateService);
        }

        [Fact]
        public async Task Test_Get()
        {
            var request = _fixture.Create<ExchangeRateGetRequest>();
            var response = _fixture.Create<ExchangeRateResponse>();

            _exchangeRateService.Get(request).Returns(response);

            var result = await _exchangeRateController.Get(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
        }
    }
}
