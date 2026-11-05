using System;
using System.Collections.Generic;

namespace DemoLib.Models
{
    public class MemoryOrderRepository : IOrderRepository
    {
        public List<Order> Load()
        {
            List<Order> orders = new List<Order>();

            Order order_1 = new Order();
            order_1.Items = new List<OrderItem>();
            order_1.Items.Add(new OrderItem
            {
                ProductItem = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Count = 10,
                SaleDate = new DateTime(2026, 8, 10)
            });

            Order order_2 = new Order();
            order_2.Items = new List<OrderItem>();
            order_2.Items.Add(new OrderItem
            {
                ProductItem = "Женские белые босоножки с широким каблуком среднего размера",
                Count = 10,
                SaleDate = new DateTime(2026, 9, 10)
            });

            Order order_3 = new Order();
            order_3.Items = new List<OrderItem>();
            order_3.Items.Add(new OrderItem
            {
                ProductItem = "Женские классические туфли на шпильке",
                Count = 10,
                SaleDate = new DateTime(2026, 10, 10)
            });

            orders.Add(order_1);
            orders.Add(order_2);
            orders.Add(order_3);

            return orders;
        }
    }
}