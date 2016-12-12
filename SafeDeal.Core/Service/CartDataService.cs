using SafeDeal.Core.Model;
using SafeDeal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDeal.Core.Service
{
    public class CartDataService
    {

        private static CartRepository cartRepository = new CartRepository();

        public CartDataService()
        {
        }

        public void AddCartItem(Deal deal, int amount)
        {
            cartRepository.AddCartItem(deal, amount);
        }

        public Cart GetCart()
        {
            return cartRepository.GetCart();
        }

    }
}

