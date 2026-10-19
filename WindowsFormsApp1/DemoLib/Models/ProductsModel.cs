using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_ = new List<Product>();
        private List<Order> orders_ = new List<Order>();

        public ProductsModel()
        {
            data_.Add(new Product
            {
                Name = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Category = "Кроссовки",
                Count = 10,
                Price = 1300.0,
                Supplier = "Kari",
                Parts = " 90% текстиль, 9% Этиленвинилацетат, 1% синтетика",
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185538.png"
            });
            data_.Add(new Product
            {
                Name = "Женские белые босоножки с широким каблуком среднего размера",
                Category = "Туфли",
                Count = 2,
                Price = 500.0,
                Supplier = "T-TACCARDI",
                Parts = "94% натуральная кожа, 6% полиуретан  ",
                ImagePath = "..\\..\\..\\Images\\IMG_WSd_185551.png"
            });
            data_.Add(new Product
            {
                Name = "Женские классические туфли на шпильке",
                Category = "Туфли",
                Count = 7,
                Price = 900.0,
                Supplier = "Kari",
                Parts = "96% натуральная кожа, 4% полиуретан ",
                ImagePath = "..\\..\\..\\Images\\picture.png"
            });
            Order order_1 = new Order();

            order_1.Items = new List<OrderItem>();
            order_1.Items.Add(new OrderItem
            {
                ProductItem = "Женские нежно-салатовые кроссовки с ортопедической стелькой",
                Count = 10,
                SaleDate = new System.DateTime(2026, 8, 10)
            });
            Order order_2 = new Order();

            order_2.Items = new List<OrderItem>();
            order_2.Items.Add(new OrderItem
            {
                ProductItem = "Женские белые босоножки с широким каблуком среднего размера",
                Count = 10,
                SaleDate = new System.DateTime(2026, 9, 10)
            });
            Order order_3 = new Order();

            order_3.Items = new List<OrderItem>();
            order_3.Items.Add(new OrderItem
            {
                ProductItem = "Женские классические туфли на шпильке",
                Count = 10,
                SaleDate = new System.DateTime(2026, 10, 10)
            });
            orders_.Add(order_1);
            orders_.Add(order_2);
            orders_.Add(order_3);

            UpdatePrices(orders_);
        }

        public List<Product> Load()
        {
            return data_;
        }

        public int GetCountProducts()
        {
            return data_.Count;
        }

        public void UpdatePrices(List<Order> orders)
        {
            DateTime current = DateTime.Now; // 10.10.2026
           
            DateTime prevMontsDate = current.AddMonths(-1); // 10.09.2026
            DateTime start = new DateTime(prevMontsDate.Year, prevMontsDate.Month, 1); // 01.09.2026
            DateTime end = new DateTime(prevMontsDate.Year, prevMontsDate.Month + 1, 1).AddDays(-1);

            List<Product> discountProducts = data_
               .Where(product => !orders
                   .SelectMany(order => order.Items)
                   .Any(item => item.ProductItem == product.Name
                   && item.SaleDate >= start
                   && item.SaleDate <= end))
               .ToList();

            foreach (Product product in discountProducts)
            {
                product.Price = product.Price * 0.75;
            }
        }
    }
}
