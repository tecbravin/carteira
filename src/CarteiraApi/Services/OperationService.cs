using AutoMapper;
using CarteiraApi.Interfaces.Repositories;
using CarteiraApi.Interfaces.Services;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Models.Responses;
using CarteiraApi.Models.Responses.Stock;
using CarteiraApi.Models.Responses.Operation;
using CarteiraApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CarteiraApi.Services
{
    public class OperationService : IOperationService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<OperationService> _logger;
        private readonly IStockRepository _StockRepository;
        private readonly IOperationRepository _OperationRepository;
        private readonly IStockParameterRepository _StockParameterRepository;

        public OperationService(
            IOperationRepository OperationRepository,
            IStockRepository StockRepository,
            IStockParameterRepository StockRulesRepository,
            IMapper mapper,
            ILogger<OperationService> logger
        )
        {
            _logger = logger;
            _mapper = mapper;
            _StockRepository = StockRepository;
            _OperationRepository = OperationRepository;
            _StockParameterRepository = StockRulesRepository;
        }

        public async Task<BaseResponse> Add(OperationAddRequest request)
        {
            try
            {
                var StocksExists = await _StockRepository.Exists(new StockGetRequest { StockCode = request.StockCode });

                if (!StocksExists)
                    return new BaseResponse { StatusCode = StatusCodes.Status409Conflict, ErrorMessage = Resource.StockNotFound };

                var Stocks = await _StockRepository.Search(new StockGetRequest { StockCode = request.StockCode });
                request.StockId = Stocks.FirstOrDefault().Id;
                request.Date = DateTime.Now;
                request.TotalAmount = await CalculateTotalAmount(request);
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var createdId = await _OperationRepository.Add(request);
                    transaction.Complete();

                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError };
            }
            return new BaseResponse { StatusCode = StatusCodes.Status201Created };
        }

        public async Task<OperationGetResponse> Get(OperationGetRequest request)
        {
            try
            {
                var StocksEvents = await _OperationRepository.Get(request);

                if (StocksEvents == null || !StocksEvents.Any())
                    return new OperationGetResponse { StatusCode = StatusCodes.Status204NoContent };

                var StocksEventsResponse = _mapper.Map<OperationGetResponse>(StocksEvents);
                foreach (var Operation in StocksEventsResponse.Operations.ToList())
                {
                    var Stocks = await _StockRepository.Search(new StockGetRequest { Id = Operation.Stock.Id });
                    Operation.Stock = _mapper.Map<StockResponse>(Stocks.FirstOrDefault());
                }
                return StocksEventsResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new OperationGetResponse { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        private async Task<decimal> CalculateTotalAmount(OperationAddRequest request)
        {
            var fees = await _StockParameterRepository.Get(StockParameter.Fees);
            var brokerageCost = await _StockParameterRepository.Get(StockParameter.BrokerageCost);

            var totalAmount = request.Price * request.Quantity;
            totalAmount += Convert.ToDecimal(brokerageCost.Value);
            totalAmount += Convert.ToDecimal((totalAmount * Convert.ToDecimal(fees.Value)) / 100);

            return totalAmount;
        }

    }
}
