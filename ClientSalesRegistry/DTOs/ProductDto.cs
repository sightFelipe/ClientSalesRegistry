namespace ClientSalesRegistry.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal PriceWithTax => PriceWithoutTax * 1.19m; 
    }
}
