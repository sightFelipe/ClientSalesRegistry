using ClientSalesRegistry.DTOs;

namespace ClientSalesRegistry.Services.SaleService
{
    public interface ISaleService
    {
        Task<SaleDto> AddSaleAsync(SaleDto saleDto);
        Task<List<SaleDto>> GetSalesByCustomerDocumentAsync(string document); 
    }
}
