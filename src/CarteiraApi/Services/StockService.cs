using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Responses;
using CarteiraApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace CarteiraApi.Services
{
    public class StockService : IStockService
    {
        private readonly ILogger<StockService> _logger;
        private readonly IStockRepository _StockRepository;
        public StockService(ILogger<StockService> logger, IStockRepository StockRepository)
        {
            _logger = logger;
            _StockRepository = StockRepository;
        }

        public async Task<BaseResponse> Add(StockAddRequest request)
        {
            try
            {
                var exists = await _StockRepository.Exists(new StockGetRequest { StockCode = request.StockCode });

                if (exists)
                    return new BaseResponse { StatusCode = StatusCodes.Status409Conflict, ErrorMessage = Resource.AlreadyExists };

                using (var transaction = new TransactionScope())
                {
                    var createdId = await _StockRepository.Add(request);
                    transaction.Complete();

                    return new BaseResponse { StatusCode = StatusCodes.Status201Created, CreatedId = createdId };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<BaseResponse> Update(StockUpdateRequest request)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    await _StockRepository.Update(request);
                    transaction.Complete();

                    return new BaseResponse { StatusCode = StatusCodes.Status200OK };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
