using AutoMapper;
using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Models;

namespace ClientSalesRegistry.Converters
{
    public class ProductConverter : Profile
    {
        public ProductConverter()
        {

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

        }
    }
}
