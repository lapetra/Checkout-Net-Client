using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class BaseItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
