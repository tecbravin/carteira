using AutoMapper;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Responses.Stock;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace CarteiraApi.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<IEnumerable<Stock>, StockGetResponse>()
                .ForPath(dest => dest.Stocks, opt => opt.MapFrom(src => src.Select(p => new StockResponse
                {
                    Id = p.Id,
                    CompanyName = p.CompanyName,
                    StockCode = p.StockCode
                })))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => StatusCodes.Status200OK))
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedId, opt => opt.Ignore());

            CreateMap<Stock, StockResponse>();
        }
    }
}
