namespace MyCheeseShop.Model
{
    public class OrderItem
    {

        public int Id { get; set; }

        public Order order { get; set; }

        public Cheese Cheese { get; set; }

        public int Quantity { get; set; }

    }
}