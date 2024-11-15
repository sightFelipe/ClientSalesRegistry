namespace ClientSalesRegistry.DTOs
{
    public class SaleItemDto
    {
        public int Quantity { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal PriceWithTax => PriceWithoutTax * 1.19m; 
    }
}
