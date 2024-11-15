using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Models;
using AutoMapper;


namespace ClientSalesRegistry.Converters
{
    public class CustomerConverter : Profile
    {
        public CustomerConverter()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }

}
