using AutoMapper;
using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Responses.Stock;
using CarteiraApi.Models.Responses.Operation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CarteiraApi.Profiles
{
    public class OperationProfile : Profile
    {
        public OperationProfile()
        {
            CreateMap<IEnumerable<Operation>, OperationGetResponse>()
                .ForPath(dest => dest.Operations, opt => opt.MapFrom(src => src.Select(f => new OperationResponse
                {
                    Date = f.Date,
                    Operation = f.Order.GetType().GetMember(f.Order.ToString()).First().GetCustomAttribute<DescriptionAttribute>().Description,
                    Price = f.Price,
                    Quantity = f.Quantity,
                    TotalAmount = f.TotalAmount,
                    Stock = new StockResponse
                    {
                        Id = f.StockId
                    }
                })))
                .ForPath(dest => dest.StatusCode, opt => opt.MapFrom(src => StatusCodes.Status200OK))
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedId, opt => opt.Ignore());
        }
    }
}
