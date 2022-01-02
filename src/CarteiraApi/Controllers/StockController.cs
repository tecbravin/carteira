using AutoMapper;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Responses;
using CarteiraApi.Models.Responses.Stock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraApi.Controllers
{
    [Route("v{version:apiVersion}/Stock")]
    [ApiVersion("1")]
    [ApiController]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    public class StockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStockService _StockService;
        private readonly IStockRepository _StockRepository;

        public StockController(
            IMapper mapper,
            IStockService StockService,
            IStockRepository StockRepository
        )
        {
            _StockService = StockService;
            _StockRepository = StockRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Method that returns Stocks
        /// </summary>
        /// <param name="request">StockGetRequest</param>
        /// <returns>StockGetResponse</returns>
        [HttpGet()]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] StockGetRequest request)
        {
            var Stocks = await _StockRepository.Search(request);

            if (Stocks == null || !Stocks.Any())
                return new ObjectResult(null) { StatusCode = StatusCodes.Status204NoContent };

            var response = _mapper.Map<StockGetResponse>(Stocks);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Method that includes an Stock
        /// </summary>
        /// <param name="request">StockAddRequest</param>
        /// <returns>BaseResponse</returns>
        [HttpPut()]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] StockAddRequest request)
        {
            var response = await _StockService.Add(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Method that update an Stock
        /// </summary>
        /// <param name="request">StockUpdateRequest</param>
        /// <returns>BaseResponse</returns>
        [HttpPost()]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] StockUpdateRequest request)
        {
            var response = await _StockService.Update(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
