using DemoLib;
using DemoLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DemoTesting
{
    [TestClass]
    public class TOrder
    {
        [TestMethod]
        public void TestCalcDiscount()
        {
            /// заказ в октябре на товар а
            Order order_1 = new Order();
            order_1.Items = new List<OrderItem>();
            order_1.Items.Add(new OrderItem
            {
                ProductItem = "a",
                Count = 10,
                SaleDate = new System.DateTime(2026, 10, 10)
            });

            /// заказ в сентябре на товар а и b
            Order order_2 = new Order();
            order_2.Items = new List<OrderItem>();
            order_2.Items.Add(new OrderItem
            {
                ProductItem = "a",
                Count = 10,
                SaleDate = new System.DateTime(2026, 9, 10)
            });
            order_2.Items.Add(new OrderItem
            {
                ProductItem = "b",
                Count = 1,
                SaleDate = new System.DateTime(2026, 9, 10)
            });

        }
    }
}
