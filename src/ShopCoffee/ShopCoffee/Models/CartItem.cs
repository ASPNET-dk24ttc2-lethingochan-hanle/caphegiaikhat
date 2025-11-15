namespace ShopCoffee.Models
{
    public class CartItem
    {
        public int IdProduct { get; set; }
        public string Name { get; set; } = null!;
        public string? Img { get; set; }
        public long Price { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public long Total => Price * Quantity;
    }
}
