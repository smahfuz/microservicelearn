namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(string username)
        {
            UserName = username;
            
        }

        public ShoppingCart()
        {
            
        }
        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (ShoppingCartItem item in Items)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }




    }
}
