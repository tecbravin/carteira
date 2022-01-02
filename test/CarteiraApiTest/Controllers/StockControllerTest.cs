using AutoFixture;
using CarteiraApi.Controllers;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Controllers
{
    public class StockControllerTest : BaseControllerTest
    {
        private readonly IStockService _StockService;
        private readonly IStockRepository _StockRepository;
        private readonly StockController _StockController;

        public StockControllerTest()
        {
            _StockRepository = Substitute.For<IStockRepository>();
            _StockService = Substitute.For<IStockService>();
            _StockController = new StockController(_mapper, _StockService, _StockRepository);
        }

        [Fact]
        public async Task Test_Get_With_Result()
        {
            var request = _fixture.Create<StockGetRequest>();
            var responseSearchRepository = _fixture.Create<IEnumerable<Stock>>();

            _StockRepository.Search(request).Returns(responseSearchRepository);

            var result = await _StockController.Get(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(((ObjectResult)result).StatusCode, StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Test_Get_Empty_Result()
        {
            var request = _fixture.Create<StockGetRequest>();
            IEnumerable<Stock> responseSearchRepository = null;

            _StockRepository.Search(request).Returns(responseSearchRepository);

            var result = await _StockController.Get(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(((ObjectResult)result).StatusCode, StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Test_Add()
        {
            var request = _fixture.Create<StockAddRequest>();
            var response = _fixture.Create<BaseResponse>();

            _StockService.Add(request).Returns(response);

            var result = await _StockController.Add(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task Test_Update()
        {
            var request = _fixture.Create<StockUpdateRequest>();
            var response = _fixture.Create<BaseResponse>();

            _StockService.Update(request).Returns(response);

            var result = await _StockController.Update(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
        }
    }
}
