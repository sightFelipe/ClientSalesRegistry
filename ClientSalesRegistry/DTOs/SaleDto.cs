namespace ClientSalesRegistry.DTOs
{
    public class SaleDto
    {
        public DateTime SaleDate { get; set; }
        public List<SaleItemDto> SaleItems { get; set; } = new List<SaleItemDto>();
    }
}
