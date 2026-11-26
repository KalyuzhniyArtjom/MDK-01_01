using System;
using System.Collections.Generic;

namespace DemoLib.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserFullName { get; set; }
    }
}