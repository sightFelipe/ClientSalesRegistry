using AutoMapper;
using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Models;

namespace ClientSalesRegistry.Converters
{
    public class SaleConverter : Profile
    {
        public SaleConverter()
        {
            CreateMap<Sale, SaleDto>();
            CreateMap<SaleDto, Sale>();
        }
    }
}
