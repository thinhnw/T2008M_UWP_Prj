using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2008M_UWP_Prj.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public string timestamp { get; set; }
    }

    public class OrderWrapper
    {
        public string message { get; set; }
        public Order data { get; set; }
    }
    public class OrderItems
    {
        public List<CartItem> items { get; set; }
        public int id { get; set; }
    }

    public class OrderItemsWrapper
    {
        public string message { get; set; }
        public OrderItems data { get; set; }
    }


}
