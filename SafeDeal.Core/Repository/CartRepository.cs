using SafeDeal.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDeal.Core.Repository
{
   public class CartRepository
    {
        public CartRepository()
        {
        }

        static Cart MainCart = new Cart() { CartItems = new List<CartItem>() };

        public void AddCartItem(Deal deal, int amount)
        {
            //TODO: add check if already added
            MainCart.CartItems.Add(new CartItem() { Deal = deal, Amount = amount });
        }

        public Cart GetCart()
        {
            return MainCart;
        }
    }
}
