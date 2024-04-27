namespace Basket.API.Models
{
    public class ShoppingCartItem
    {
        public int Qty { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        
    }
}
