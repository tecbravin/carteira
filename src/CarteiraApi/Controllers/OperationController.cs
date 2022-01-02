using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarteiraApi.Controllers
{
    [Route("v{version:apiVersion}/Operation")]
    [ApiVersion("1")]
    [ApiController]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _OperationService;
        public OperationController(IOperationService OperationService)
        {
            _OperationService = OperationService;
        }

        /// <summary>
        /// Method that returns Stocks Events
        /// </summary>
        /// <param name="request">StockGetRequest</param>
        /// <returns>StockGetResponse</returns>
        [HttpGet()]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] OperationGetRequest request)
        {
            var response = await _OperationService.Get(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Method that includes an Stock Event
        /// </summary>
        /// <param name="request">StockAddRequest</param>
        /// <returns>BaseResponse</returns>
        [HttpPut()]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] OperationAddRequest request)
        {
            var response = await _OperationService.Add(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
