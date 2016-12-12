using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDeal.Core.Model
{
    public class CartItem
    {
        public CartItem()
        {
        }

        public Deal Deal
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }
    }
}
