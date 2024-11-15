using AutoMapper;
using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Models;

namespace ClientSalesRegistry.Converters
{
    public class SaleItemConverter : Profile
    {
        public SaleItemConverter() {
            CreateMap<SaleItem, SaleItemDto>();
            CreateMap<SaleItemDto, SaleItem>();
        }
    }
}
