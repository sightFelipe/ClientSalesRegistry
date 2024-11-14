namespace ClientSalesRegistry.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int CustomerId { get; set; }
        public List<SaleItemDto> SaleItems { get; set; } = new List<SaleItemDto>();
    }
}
