namespace MyCheeseShop.Model
{

    public class ShoppingCart
    {
        public event Action OnCartUpdated;
        private List<CartItem> _items; 

        public ShoppingCart()
        {
            _items = [];
        }
  
        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is null)
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            else
                item.Quantity += quantity;

           OnCartUpdated?.Invoke(); 
        }

        public int GetQuantity(Cheese cheese)
        {
            // return the quantity of the cheese in the cart
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _items; 
        }


    }
}