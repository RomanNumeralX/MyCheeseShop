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

//CUSTOM
        public double TotalCost()
        {
            double price = 0;
            double total_cost = 0;
            var amount_weight = 0;

            var items = _items;
            items.ToList();
            foreach (var item in items)
            {
                amount_weight += item.Quantity;
                price = (amount_weight / 2) * item.Cheese.Price;
                total_cost += price;
            }

            return price;

        }

//CUSTOM

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is null)
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            else
                item.Quantity += quantity;

           OnCartUpdated?.Invoke(); 
        }

        public void Clear()
        {
            _items.Clear();
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

        public void RemoveItem(Cheese cheese)
        {
            // remove the cheese from the cart
            _items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            OnCartUpdated?.Invoke();
        }

        public void RemoveItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                    _items.Remove(item);
            }
            OnCartUpdated?.Invoke();
        }

        public void SetItems(IEnumerable<CartItem> items)
        {
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }


    }
}