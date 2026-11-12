using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_ = new List<Product>();
        private List<Order> orders_ = new List<Order>();
        IOrderRepository repository_;

        public ProductsModel(IOrderRepository repository)
        {
            repository_ = repository;

            // 1. Загружаем товары из базы данных (а не из памяти!)
            data_ = repository_.LoadProducts();

            // 2. Загружаем заказы (пока что вернется пустой список, так как метод-заглушка)
            orders_ = repository_.Load();

            // 3. Пересчитываем скидки (если есть заказы за прошлый месяц)
            UpdatePrices(orders_);
        }

        public void UpdateListModel(List<Product> newProducts)
        {
            if (newProducts == null)
            {
                data_ = new List<Product>();
            }
            else
            {
                data_ = new List<Product>(newProducts);
            }
        }

        public List<Product> Load()
        {
            return data_;
        }

        public List<Order> LoadOrders()
        {
            return orders_;
        }

        public int GetCountProducts()
        {
            return data_.Count;
        }

        public void UpdatePrices(List<Order> orders)
        {
            DateTime current = DateTime.Now;
            DateTime prevMonthsDate = current.AddMonths(-1);
            DateTime start = new DateTime(prevMonthsDate.Year, prevMonthsDate.Month, 1);
            DateTime end = new DateTime(prevMonthsDate.Year, prevMonthsDate.Month + 1, 1).AddDays(-1);

            // Если список заказов пустой, то скидку получают все товары
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