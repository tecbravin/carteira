using AutoFixture;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Models.Responses;
using CarteiraApi.Models.Responses.Operation;
using CarteiraApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Services
{
    public class OperationServiceTest : BaseServiceTest
    {
        private readonly ILogger<OperationService> _logger;
        private readonly IStockRepository _StockRepository;
        private readonly IOperationRepository _OperationRepository;
        private readonly IStockParameterRepository _StockRulesRepository;
        private readonly IOperationService _OperationService;

        public OperationServiceTest()
        {
            _logger = Substitute.For<ILogger<OperationService>>();
            _StockRepository = Substitute.For<IStockRepository>();
            _OperationRepository = Substitute.For<IOperationRepository>();
            _StockRulesRepository = Substitute.For<IStockParameterRepository>();
            _OperationService = new OperationService(_OperationRepository, _StockRepository, _StockRulesRepository, _mapper, _logger);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Test_Add(bool exist)
        {
            var request = _fixture.Create<OperationAddRequest>();
            var StockSearchResponse = _fixture.Create<IEnumerable<Stock>>();

            var StockParameter = _fixture.Create<StockParameter>();
            StockParameter.Value = "2";

            var response = _fixture.Create<int>();

            _StockRepository.Exists(Arg.Any<StockGetRequest>()).Returns(exist);
            _StockRepository.Search(Arg.Any<StockGetRequest>()).Returns(StockSearchResponse);
            _OperationRepository.Add(request).Returns(response);
            _StockRulesRepository.Get(Arg.Any<int>()).Returns(StockParameter);

            var result = await _OperationService.Add(request);

            if (!exist)
                Assert.Equal(result.StatusCode, StatusCodes.Status409Conflict);
            else
            {
                Assert.NotNull(result);
                Assert.IsType<BaseResponse>(result);
                Assert.Equal(result.StatusCode, StatusCodes.Status201Created);
            }
        }

        [Fact]
        public async Task Test_Get_With_Result()
        {
            var request = _fixture.Create<OperationGetRequest>();
            var responseSearchRepository = _fixture.Create<IEnumerable<Operation>>();

            _OperationRepository.Get(request).Returns(responseSearchRepository);

            var result = await _OperationService.Get(request);

            Assert.NotNull(result);
            Assert.IsType<OperationGetResponse>(result);
            Assert.Equal(result.StatusCode, StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Test_Get_Empty_Result()
        {
            var request = _fixture.Create<OperationGetRequest>();
            IEnumerable<Operation> responseSearchRepository = null;

            _OperationRepository.Get(request).Returns(responseSearchRepository);

            var result = await _OperationService.Get(request);

            Assert.NotNull(result);
            Assert.IsType<OperationGetResponse>(result);
            Assert.Equal(result.StatusCode, StatusCodes.Status204NoContent);
        }
    }
}
