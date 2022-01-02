using AutoFixture;
using CarteiraApi.Controllers;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Models.Responses;
using CarteiraApi.Models.Responses.Operation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace CarteiraApiTest.Controllers
{
    public class OperationControllerTest : BaseControllerTest
    {
        private readonly IOperationService _OperationService;
        private readonly OperationController _StockController;

        public OperationControllerTest()
        {
            _OperationService = Substitute.For<IOperationService>();
            _StockController = new OperationController(_OperationService);
        }

        [Fact]
        public async Task Test_Get()
        {
            var request = _fixture.Create<OperationGetRequest>();
            var response = _fixture.Create<OperationGetResponse>();

            _OperationService.Get(request).Returns(response);

            var result = await _StockController.Get(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task Test_Add()
        {
            var request = _fixture.Create<OperationAddRequest>();
            var response = _fixture.Create<BaseResponse>();

            _OperationService.Add(request).Returns(response);

            var result = await _StockController.Add(request);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
        }
    }
}
