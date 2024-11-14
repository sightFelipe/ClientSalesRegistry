namespace ClientSalesRegistry.DTOs
{
    public class SaleItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal PriceWithTax => PriceWithoutTax * 1.19m; 
    }
}
