namespace Greggs.Products.Api.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal PriceInPounds { get; set; }
        public string Currency { get; set; } //to indicate the currency (gbp/eur)
    }
}
