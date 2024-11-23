namespace ProductsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StockQte { get; set; }
        public double Price { get; set; }
    }


}
