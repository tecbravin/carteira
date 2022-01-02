using AutoFixture;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Responses;
using CarteiraApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Services
{
    public class StockServiceTest : BaseServiceTest
    {
        private readonly ILogger<StockService> _logger;
        private readonly IStockRepository _StockRepository;
        private readonly IStockService _StockService;
        public StockServiceTest()
        {
            _logger = Substitute.For<ILogger<StockService>>();
            _StockRepository = Substitute.For<IStockRepository>();
            _StockService = new StockService(_logger, _StockRepository);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Test_Add(bool exist)
        {
            var request = _fixture.Create<StockAddRequest>();
            var response = _fixture.Create<int>();

            _StockRepository.Exists(Arg.Any<StockGetRequest>()).Returns(exist);
            _StockRepository.Add(request).Returns(response);

            var result = await _StockService.Add(request);

            if (exist)
                Assert.Equal(result.StatusCode, StatusCodes.Status409Conflict);
            else
            {
                Assert.NotNull(result);
                Assert.IsType<BaseResponse>(result);
                Assert.Equal(result.StatusCode, StatusCodes.Status201Created);
            }
        }

        [Fact]
        public async Task Test_Update()
        {
            var request = _fixture.Create<StockUpdateRequest>();

            var result = await _StockService.Update(request);

            Assert.NotNull(result);
            Assert.IsType<BaseResponse>(result);
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
        }
    }
}
